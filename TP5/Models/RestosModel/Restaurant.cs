﻿using System.Collections.Generic;
using RestoManager_YourName.Models.RestosModel; // ✅ Required for Avis

namespace RestoManager_YourName.Models.RestosModel
{
    public class Restaurant
    {
        public int CodeResto { get; set; }
        public string NomResto { get; set; }
        public string Specialite { get; set; }
        public string Ville { get; set; }
        public string Tel { get; set; }

        public int NumProp { get; set; }

        // Navigation
        public Proprietaire LeProprio { get; set; }
        public ICollection<Avis> LesAvis { get; set; }
    }
}