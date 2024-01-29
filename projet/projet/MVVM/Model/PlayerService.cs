using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet.MVVM.Model
{
    public class PlayerService
    {
        private Player _player;

        public Player Player
        {
            get { return _player; }
            set
            {
                _player = value;
            }
        }
    }
}
