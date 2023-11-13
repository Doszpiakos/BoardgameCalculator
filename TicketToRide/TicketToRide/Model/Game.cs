using System;
using System.Collections.Generic;
using System.Text;

namespace TicketToRide.Model
{
    class Game
    {
        List<Player> players;

        public Game()
        {
            players = new List<Player>();
        }

        public void CreatePlayer(Player player)
        {
            players.Add(player);
        }

        public void DeletePlayer(Player player)
        {
            players.Remove(player);
        }
    }
}
