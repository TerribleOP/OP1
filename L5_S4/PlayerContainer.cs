using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_4
{
    class PlayerContainer
    {
        private Player[] players;
        public int Count { get; private set; }
        private int Capacity;

        public PlayerContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.players = new Player[capacity];
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Player[] temp = new Player[minimumCapacity];
                for (int i = 0; i < this.Count; ++i)
                {
                    temp[i] = this.players[i];
                }
                this.Capacity = minimumCapacity;
                this.players = temp;
            }
        }

        public Player Get(int index)
        {
            return this.players[index];
        }

        public bool Contains(Player player)
        {
            return this.players.Contains(player);
        }

        public void Add(Player player)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.players[this.Count++] = player;
        }

        public void Put(Player player, int index)
        {
            if (index >= 0 && index < this.Count)
            {
                this.players[index] = player;
            }
        }

        public void Insert(Player player, int index)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count - 1; i >= index; i--)
            {
                players[i + 1] = this.players[i];
            }
            this.players[index] = player;
            this.Count++;
        }
        public void Remove(Player player)
        {
            int index = -1;
            for (int i = 0; i < this.Count - 1; i++)
            {
                if (this.players[i].playerLastName == player.playerLastName)
                {
                    index = i;
                }
            }
            if (index > -1)
            {
                RemoveAt(index);
            }

        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.players[i] = this.players[i + 1];
            }
            players[this.Count - 1] = null;
            this.Count--;
        }

        public void Sort()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < this.Count; j++)
                {
                    if (false)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Player temp = this.players[i];
                    this.players[i] = this.players[minIndex];
                    this.players[minIndex] = temp;
                }
            }
        }

    }
}
