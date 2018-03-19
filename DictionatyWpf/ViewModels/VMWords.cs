﻿using System.Collections.ObjectModel;
using System.Windows;
using DictionatyWpf.Data;
using DictionatyWpf.Models;
using DictionatyWpf.Views;

namespace DictionatyWpf.ViewModels
{
    public class VMWords : VMBase
    {
        #region Declarations

        #endregion

        #region Properties

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof(ObservableCollection<Word>), typeof(VMWords), new PropertyMetadata(default(ObservableCollection<Word>)));

        public ObservableCollection<Word> ItemsSource
        {
            get { return (ObservableCollection<Word>) GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        #endregion

        #region Constructorss

        public VMWords(DataManager dm, object param) : base(dm)
        {
            LoadWords();
        }

        #endregion


        #region Private Methods

        private void LoadWords()
        {
            if (DM != null)
            {
                IsLoading = true;
                DM.GetAllWordsAsync(WordsLoaded);
                //ItemsSource = new ObservableCollection<Word>(DM.GetAllWords());
            }
        }

        private void WordsLoaded(System.Collections.Generic.List<Word> obj)
        {
            IsLoading = false;
            ItemsSource = new ObservableCollection<Word>(obj);
        }

        public override bool Command_CanExecute(Command command, object param)
        {
            var res = false;
            if (command == Command.AddEditWord)
            {
                res = true;
            }
            else
            {
                res = base.Command_CanExecute(command, param);
            }

            return res;
        }

        public override void Command_Executed(Command command, object param)
        {
            if (command == Command.AddEditWord)
            {
                OpenScreen(ScreenId.AddEditWord, param);
            }
            else
            {
                base.Command_Executed(command, param);
            }
        }

        #endregion

        #region Public Methods




        #endregion

        #region Events



        #endregion
    }
}