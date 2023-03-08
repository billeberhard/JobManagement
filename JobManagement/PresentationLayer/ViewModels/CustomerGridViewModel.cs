using System.Collections.Generic;
using System.Data;
using PresentationLayer.Core;

namespace PresentationLayer.ViewModels;

public class CustomerGridViewModel : ViewModel
{
    public CustomerGridViewModel()
    {
        
    }

    public void AddHeader(DataTable dataTable)
    {
        // add header data
        dataTable.Columns.Add("Customer ID");
        dataTable.Columns.Add("Firstname");
        dataTable.Columns.Add("Lastname");
        dataTable.Columns.Add("Email Address");
        dataTable.Columns.Add("Streetname");
        dataTable.Columns.Add("City");
        dataTable.Columns.Add("Website URL");
        dataTable.Columns.Add("Password");
    }

    public void AddRow()
    {

    }
}