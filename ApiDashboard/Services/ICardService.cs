using ApiDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDashboard.Services
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetCards();
        Task<Card> GetCard(int id);
        Task<IEnumerable<Card>> GetCardsByTitle(string title);
        Task CreateCard(Card card);
        Task UpdateCard(Card card);
        Task DeleteCard(Card card);
    }
}
