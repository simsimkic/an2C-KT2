﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourist_Project.Domain.Models;
using Tourist_Project.Applications.UseCases;
using System.Windows.Input;

namespace Tourist_Project.WPF.ViewModels
{
    public class RateAccommodationViewModel
    {

        private Window _window;
        private AccommodationRatingService _accommodationRatingService = new AccommodationRatingService();
        private AccommodationService _accommodationService = new AccommodationService();
        //sad samo treba da prihvatim parametre i da ih upisem u fajlove
        public int Rating { get; set; }

        public String Comment { get; set; }
        public String ImageUrl { get; set; }

        public String OwnerComment { get; set; }

        public bool IsChecked { get; set; }
        
        //treba da sacuvam AccommodationRating

        public Accommodation SelectedAccommodation { get; set; }
        public AccommodationRating AccommodationRating { get; set; }    

        public ICommand Confirm_Command { get; set; }

        public RateAccommodationViewModel(Window window)
        {
            this._window = window;
            IsChecked = false;
            Confirm_Command = new RelayCommand(RateAccommodation, CanCreate);

        }

        private bool CanCreate()
        {
            if(IsChecked)
            {
                Rating = 5;//zakucana vrednost da ne bih sad gubio vreme sa pravljenjem konvertera
                return true;
            }
            return false;
        }

        private void RateAccommodation()
        {
            _accommodationRatingService.Create(AccommodationRating);
        }
        //sad jos moram da preuzmem podatke od SelectedAccommodation-a za upis u fajlove i to bi trebalo da je to
    }
}
