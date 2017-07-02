using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_mvc_f.Models
{
    public class Character
    {
        public string Name;
        public static List<Character> Characters { get; set; }
            //if the event our character property is null,it will use whatever we set after the = as the default value.
            = new List<Character>();
        public static void Create(string characterName) {
            var character = new Character();
            character.Name = characterName;
            
            if (GloablVariables.Characters == null) {
                GloablVariables.Characters = new List<Character>();
            }
            
            GloablVariables.Characters.Add(character);
        }

        //get all the eles
        public static List<Models.Character> GetAll() {
            
            if (GloablVariables.Characters == null)
                GloablVariables.Characters = new List<Character>();
                
            return GloablVariables.Characters;
        }
    }
}