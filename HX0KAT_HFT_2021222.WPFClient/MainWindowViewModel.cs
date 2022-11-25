﻿using HX0KAT_HFT_2021222.Models;
using HX0KAT_HFT_2021222.WPFClient.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace HX0KAT_HFT_2021222.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Customer> Customers { get; set; }
        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (value != null)
                {
                    selectedCustomer = new Customer()
                    {
                        FirstName = value.FirstName,
                        LastName = value.LastName,
                        Email = value.Email,
                        Id = value.Id,
                        Phone = value.Phone,
                    };
                    OnPropertyChanged();
                    (DeleteCustomerCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateCustomerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand UpdateCustomerCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Customers = new RestCollection<Customer>("http://localhost:5236/", "Customer", "hub");
                CreateCustomerCommand = new RelayCommand(() =>
                {
                    Customer customer = new Customer();
                    CustomerEditorView CustomerEditor = new CustomerEditorView(customer);
                    if (CustomerEditor.ShowDialog() == true)
                    {
                        Customers.Add(customer);
                    }
                    //Customers.Add(new Customer() //Itt új ablakban kéne létrehozni az újat
                    //{
                    //    FirstName = SelectedCustomer.FirstName,
                    //    LastName = SelectedCustomer.LastName,
                    //    Email = SelectedCustomer.Email,
                    //    Id = SelectedCustomer.Id,
                    //    Phone = SelectedCustomer.Phone,
                    //});
                });

                UpdateCustomerCommand = new RelayCommand(() =>
                {
                    try
                    {
                        CustomerEditorView CustomerEditor = new CustomerEditorView(SelectedCustomer);
                        if (CustomerEditor.ShowDialog() == true)
                        {
                            Customers.Update(SelectedCustomer);
                        }                        
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                },
                () =>
                {
                    return SelectedCustomer != null;
                });

                DeleteCustomerCommand = new RelayCommand(() =>
                {
                //Dispatcher.Invoke((Action)(() =>
                // Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                Customers.Delete(SelectedCustomer.Id);
                    //));
                },
                () =>
                {
                    return SelectedCustomer != null;
                });
                SelectedCustomer = new Customer();
            }
        }
    }
}
