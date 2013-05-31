using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StyleMVVM.DependencyInjection;
using StyleMVVM.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;

namespace w8_LottoGenerator.ViewModels
{
	public class MainPageViewModel : PageViewModel
	{
        private string results;
        public string Results
        {
            get { return results; }
            set 
            { 
                results = value;
                OnPropertyChanged("Results");
            }
        }

        private Visibility fullGrid = Visibility.Visible;
        public Visibility FullGrid
        {
            get { return fullGrid; }
            set
            {
                fullGrid = value;
                OnPropertyChanged("FullGrid");
            }

        }

        private Visibility snapGrid = Visibility.Collapsed;
        public Visibility SnapGrid
        {
            get { return snapGrid; }
            set
            {
                snapGrid = value;
                OnPropertyChanged("SnapGrid");
            }
        }


        private void TryUnsnapView()
        {
            Windows.UI.ViewManagement.ApplicationView.TryUnsnap();
            SnapGrid = Visibility.Collapsed;
            FullGrid = Visibility.Visible;
        }



        public MainPageViewModel()
        {

            
            FullGrid = Visibility.Visible;
            SnapGrid = Visibility.Collapsed;

            InitView();


        }

        void InitView()
        {
            Window.Current.SizeChanged += OnSizeChanged;
        }

        protected override void OnNavigatedTo(object sender, StyleMVVM.View.StyleNavigationEventArgs e)
        {
            InitView();
            base.OnNavigatedTo(sender, e);
        }


        private void OnSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            // Obtain view state by explicitly querying for it
            if (Windows.UI.ViewManagement.ApplicationView.Value == ApplicationViewState.Snapped)
            {
                SnapGrid = Visibility.Visible;
                FullGrid = Visibility.Collapsed;
            }
            else
                if (Windows.UI.ViewManagement.ApplicationView.Value == ApplicationViewState.Filled || Windows.UI.ViewManagement.ApplicationView.Value == ApplicationViewState.FullScreenLandscape)
                {
                    SnapGrid = Visibility.Collapsed;
                    FullGrid = Visibility.Visible;
                }
        }




        Random rand = new Random();

        private void Random(int _min, int _max, int _count)
        {
            Results = "";

            
            for (int i = 0; i < _count; i++)
            {
                Results += (rand.Next(_min, _max)).ToString() + " ";
            }
        }

        private void RandomLotto()
        {
            Random(1, 49, 6);
        }

        private void RandomLottoPlus()
        {
            Random(1, 49, 1);
        }

        private void RandomMultiMulti()
        {
            Random(1, 80, 10);
        }

        private void RandomMini()
        {
            Random(1, 42, 5);
        }


        private void RandomJoker()
        {
            Random(1, 36, 1);
        }


        
	}
}
