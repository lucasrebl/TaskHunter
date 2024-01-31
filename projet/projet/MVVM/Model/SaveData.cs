using Inventorys;
using Monsters;
using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet.MVVM.Model
{
    [Serializable]
    public class SaveData
    {
        public Player Player { get; set; }
        public Monster Monster { get; set; }
    }
}
