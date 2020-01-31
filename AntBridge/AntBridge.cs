using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AntBridge
{
    public class AntBridge
    {
        public string Bridge(string ants, string terrain)
        {
            if (terrain.Distinct().Count() == 1)
            {
                return ants;
            }


            var antsArray = ants.Select((x, i) => new Ant(x, i)).ToList();
            // Assumption: more than 3 terrains between gaps:
            string newTerrain = transforTerrain(terrain);
            var terainList = newTerrain.ToList();

            var result = Regex.Matches(newTerrain, "-\\.{1,}-");

            foreach (Match gap in result)
            {
                if (antsArray.Count < gap.Value.Length)
                    throw new System.Exception();

                int notUsedAnts = antsArray.Count - gap.Value.Length;
                List<Ant> newAnts = new List<Ant>();
               
                newAnts.AddRange(antsArray.Skip(notUsedAnts));
                newAnts.AddRange(antsArray.Take(notUsedAnts));
                antsArray = newAnts;
            }

            return new string(antsArray.Select(x=>x.Id).ToArray());
        }

        private string transforTerrain(string terrain)
        {
            return terrain.Replace(".-.", "...").Replace(".--.", "....");
        }
    }

    class Ant
    {
        public char Id { get; set; }
        public int Pos { get; set; }
        public Ant(char id,int pos)
        {
            Id = id;
            Pos = pos;
        }
    }
}