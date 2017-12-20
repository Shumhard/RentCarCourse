﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DbWorkers;
using Models;
using Microsoft.Win32;

namespace RentCar.Controls
{
    /// <summary>
    /// Логика взаимодействия для PersonnelInfoEdit.xaml
    /// </summary>
    public partial class PersonnelInfoEditControl : UserControl
    {
        public event EventHandler EditEnded;

        public PersonnelInfoEditControl()
        {
            InitializeComponent();
        }

        private void LoadImageBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Загрузка новой аватарки клиента
            var model = (PersonnelCabinetWindowModel)this.DataContext;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bitmap files (*.bmp)|*.bmp|Image jpg files (*.jpg)|*.jpg|Image png files (*.png)|*.png";
            ofd.FilterIndex = 2;
            ofd.Title = "Давай быстрее";
            ofd.RestoreDirectory = true;

            bool?result = ofd.ShowDialog();

            if(result == true)
            {
                string fileName = ofd.FileName;
                string filePath = ofd.InitialDirectory.ToString() + fileName;
                model.ImagePath = filePath;
                Image.Source = BitmapFrame.Create(new Uri(model.ImagePath));
            }

            //  sqlQuery imagePath update
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Сохранение новой инфы о клиенте
            var model = (PersonnelCabinetWindowModel)this.DataContext;

            model.Login = LoginTxt.Text;

            if(Password.Password == RepeatPassword.Password)
            {
                if(Password.Password != null)
                    model.Password = Password.Password;

                model.SecondName = SecondNameTxt.Text;
                model.FirstName = FirstNameTxt.Text;
                model.Patronymic = PatronymicTxt.Text;
                model.Phone = PhoneTxt.Text;
                model.Email = EmailTxt.Text;
                model.Burthday = BurthdayTxt.Text;
                var sexList = SexCmb.ItemsSource;
                model.Sex = SexCmb.SelectedValue.ToString();
                //  SexCmb.SelectedIndex
                model.PassportSeria = PassportSeriaTxt.Text;
                model.PassportNumber = PassportNumberTxt.Text;
                model.BankCard = BankCard.Text;

                //  sqlQuery UPDATE

                Close();
            }
            else
            {
                //  show error
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close()
        {
            if(EditEnded != null)
            {
                EditEnded(this, new EventArgs());
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            var model = (PersonnelCabinetWindowModel)window.DataContext;
            DataContext = model;
            
            LoginTxt.Text = model.Login;
            //Password.Password = model.Password;
            //RepeatPassword.Password = model.PasswordString;
            Password.Clear();
            RepeatPassword.Clear();
            SecondNameTxt.Text = model.SecondName;
            FirstNameTxt.Text = model.FirstName;
            PatronymicTxt.Text = model.Patronymic;
            PhoneTxt.Text = model.Phone;
            EmailTxt.Text = model.Email;
            BurthdayTxt.Text = model.Burthday;
            var sexList = DbReferenceWorker.GetSexReference();
            SexCmb.ItemsSource = sexList;
            Int32 sexIndex;
            foreach(Common.ReferenceValue sex in sexList)
            {
                if (sex.Name == model.Sex)
                {
                    sexIndex = sex.Id;
                    SexCmb.SelectedIndex = sexIndex;
                    break;
                }                    
            }
            PassportSeriaTxt.Text = model.PassportSeria;
            PassportNumberTxt.Text = model.PassportNumber;
            BankCard.Text = model.BankCard;
            model.ImagePath = "C:\\\\Users\\zel1b08a\\Pictures\\pasport.jpg";
            Image.Source = BitmapFrame.Create(new Uri(model.ImagePath));
        }
    }
}