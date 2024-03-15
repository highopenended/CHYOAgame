using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.Sets
{
    public class GameManager
    {
        CharacterCreation.Set_Manager CharacterCreation_Manager = new CharacterCreation.Set_Manager();
        
        public void StartGame()
        {
            CharacterCreation_Manager.Start_Scene();
        }
    }
}
