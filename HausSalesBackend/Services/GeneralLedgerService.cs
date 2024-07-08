using AutoMapper;
using HausSalesBackend.Data;
using HausSalesBackend.Models;
using HausSalesBackend.Models.DTOs;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace HausSalesBackend.Services
{
    public class GeneralLedgerService
    {
        private readonly ApplicationDbContext _context;
        private static int accountNumberCounter = 1;
        private static readonly object lockObject = new object();
        private readonly IMapper _mapper;

        public GeneralLedgerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GeneralLedger>> GetGeneralLedgersAsync()
        {
            return await _context.GeneralLedgers.ToListAsync();
        }

        public async Task<GeneralLedger> GetGeneralLedgerByIdAsync(int id)
        {
            return await _context.GeneralLedgers.FindAsync(id);
        }

        public async Task<GeneralLedger> AddGeneralLedgerAsync(GLedgerDto dto)
        {
            var ledger = _mapper.Map<GeneralLedger>(dto);
            ledger.glId = Guid.NewGuid();
            ledger.accountNumber = GenerateAccountNumber();

            _context.GeneralLedgers.Add(ledger);
            await _context.SaveChangesAsync();
            return ledger;
        }

        public async Task<bool> UpdateGeneralLedgerAsync(GeneralLedger ledger)
        {
            _context.Entry(ledger).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LedgerExists(ledger.glId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteGeneralLedgerAsync(int id)
        {
            var product = await _context.GeneralLedgers.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.GeneralLedgers.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool LedgerExists(Guid id)
        {
            return _context.GeneralLedgers.Any(e => e.glId == id);
        }

        private string GenerateAccountNumber()
        {
            const string prefix = "GL"; // Two-letter prefix
            const int numberOfDigits = 6; // Number of digits following the prefix
            string accountNumber;

            lock (lockObject)
            {
                accountNumber = $"{prefix}{accountNumberCounter.ToString($"D{numberOfDigits}")}";
                accountNumberCounter++;
            }

            return accountNumber;
        }
    }
}
