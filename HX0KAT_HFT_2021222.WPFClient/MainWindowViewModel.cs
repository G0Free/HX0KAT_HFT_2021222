using HX0KAT_HFT_2021222.Models;
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

        #region Customer
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

        #endregion

        #region Phone

        public RestCollection<Phone> Phones { get; set; }
        private Phone selectedPhone;

        public Phone SelectedPhone
        {
            get
            {
                return selectedPhone;
            }
            set
            {
                if (value != null)
                {
                    selectedPhone = new Phone()
                    {
                        Id = value.Id,
                        Brand = value.Brand,
                        Model = value.Model,
                        Price = value.Price,
                        CustomerId = value.CustomerId,
                        RepairerId = value.RepairerId,
                    };
                    OnPropertyChanged();
                    (DeletePhoneCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdatePhoneCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreatePhoneCommand { get; set; }
        public ICommand DeletePhoneCommand { get; set; }
        public ICommand UpdatePhoneCommand { get; set; }

        #endregion

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
                #region Customer

                Customers = new RestCollection<Customer>("http://localhost:5236/", "Customer", "hub");
                CreateCustomerCommand = new RelayCommand(() =>
                {
                    Customer customer = new Customer();
                    CustomerEditorView CustomerEditor = new CustomerEditorView(customer);
                    if (CustomerEditor.ShowDialog() == true)
                    {
                        Customers.Add(customer);
                    }
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
                    Customers.Delete(SelectedCustomer.Id);
                },
                () =>
                {
                    return SelectedCustomer != null;
                });
                SelectedCustomer = new Customer();

                #endregion

                #region Phone

                Phones = new RestCollection<Phone>("http://localhost:5236/", "Phone", "hub");

                CreatePhoneCommand = new RelayCommand(() =>
                {
                    Phone phone = new Phone();
                    PhoneEditorView PhoneEditor = new PhoneEditorView(phone);
                    if (PhoneEditor.ShowDialog() == true)
                    {
                        Phones.Add(phone);
                    }
                });

                UpdatePhoneCommand = new RelayCommand(() =>
                {
                    try
                    {
                        PhoneEditorView PhoneEditor = new PhoneEditorView(SelectedPhone);
                        if (PhoneEditor.ShowDialog() == true)
                        {
                            Phones.Update(SelectedPhone);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                },
                () =>
                {
                    return SelectedPhone != null;
                });

                DeletePhoneCommand = new RelayCommand(() =>
                {
                    Phones.Delete(SelectedPhone.Id);
                },
                () =>
                {
                    return SelectedPhone != null;
                });
                SelectedPhone = new Phone();

                #endregion
            }
        }
    }
}
