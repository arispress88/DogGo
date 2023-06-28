using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DogGo.Models;
using System.ComponentModel;

namespace DogGo.Models.ViewModels
{
    public class WalkFormViewModel
    {
        public Walk Walk { get; set; }
        public List<Walker> Walkers { get; set; }
        public List<Dog> Dogs { get; set; }

        [DisplayName("Dog(s) (hold 'Control' key to select multiple dogs")]
        public List<int> SelectedDogIds { get; set; }
    }
}
