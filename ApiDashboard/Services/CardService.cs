using ApiDashboard.Context;
using ApiDashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDashboard.Services
{
    public class CardService : ICardService
    {
        private readonly AppDbContext _context;

        public CardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            try
            {
                return await _context.TB_Card.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Card>> GetCardsByTitle(string title)
        {
            IEnumerable<Card> cards;

            try
            {    
                if (!string.IsNullOrWhiteSpace(title))
                {
                    cards = await _context.TB_Card.Where(n => n.Title.Contains(title)).ToListAsync();
                }
                else
                {
                    cards = await GetCards();
                }
            }
            catch
            {
                throw;
            }
            return cards;
        }

        public async Task<Card> GetCard(int id)
        {
            try
            {
                var cards = await _context.TB_Card.FindAsync(id);
                return cards;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateCard(Card card)
        {
            try
            {
                _context.TB_Card.Add(card);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

        }

        public async Task UpdateCard(Card card)
        {
            try
            {
                _context.Entry(card).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteCard(Card card)
        {
            try
            {
                _context.TB_Card.Remove(card);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
