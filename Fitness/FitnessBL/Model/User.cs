﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    [Serializable]
    public class User
    {
        #region Propperties
        public string Name { get; }
        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Verification of conditions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can't eb empty!", nameof(name));
            }
            
            if(gender == null)
            {
                throw new ArgumentNullException("Gender can't be empty!", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birthday!", nameof(birthDate));
            }
            
            if(weight <= 0)
            {
                throw new ArgumentException("Weight can't be less or 0", nameof(weight));
            }

            if(height <= 0)
            {
                throw new ArgumentException("Height can't be less or 0", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can't eb empty!", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
