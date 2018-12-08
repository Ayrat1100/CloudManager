﻿using CloudManader1._0.ViewModels;
using Fasetto.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CloudManader1._0
{
    /// <summary>
    /// the View  Model for the custom window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// the window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// the margin drop shadow around window
        /// </summary>
        private int mOuterMarginSize = 10;
        
        /// <summary>
        /// Corner radius of window
        /// </summary>
        private int mWindowRadius = 3;
        #endregion

        #region Constructor

        /// <summary>
        /// Defoult constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;
            mWindow.StateChanged += (sender, e) => 
            {
                OnPropertyChanged(nameof(ResizeBorderThikness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThikness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            //create commands
            MinimizeWindowCommand = new RelayCommand(()=> mWindow.WindowState = WindowState.Minimized);
            MaximizeWindowCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseWindowCommand = new RelayCommand(() => mWindow.Close());
            var resizer = new WindowResizer(mWindow);
        }

        #endregion

        #region Public properties

        /// <summary>
        /// the size of the  resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 0;

        /// <summary>
        /// Size of the resize border around the window
        /// </summary>
        public Thickness ResizeBorderThikness { get { return new Thickness(ResizeBorder+OuterMarginSize); }}

        /// <summary>
        /// Size of the resize border around the window
        /// </summary>
        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }

        /// <summary>
        /// the window this view model controls
        /// </summary>
        public int OuterMarginSize
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize; }
            set { mOuterMarginSize = value; }
        }  

        /// <summary>
        /// the window this view model controls
        /// </summary>
        public Thickness OuterMarginSizeThikness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// Corner radius of window
        /// </summary>
        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius; }
            set { mWindowRadius = value; }
        }

        /// <summary>
        /// Corner radius of window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public GridLength TitleHeigthGridLine { get { return new GridLength(TitleHeight+ResizeBorder); } }
        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeWindowCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeWindowCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseWindowCommand { get; set; }


        #endregion

      
    }
}