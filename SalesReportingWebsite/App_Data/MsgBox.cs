/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Drawing;

/// <summary>
/// Summary description for MsgBox
/// </summary>
public class MessageBoxClass
{
    public void MsgBox()
    {
        MessageBox.Show("Pick Complete not possible. The following fields must be filled in: " + "\n - Requested Date" + "\n - Deliver To" +
            "\n - Assigned To" + "\n - Inventory Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
    }

    public void MsgBoxUpdate()
    {
        MessageBox.Show("Unable to update fields. Pick has already been completed.", "Warning",
            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
    }

    public void MsgBoxAuthorization()
    {
        MessageBox.Show("You must be a member of SK_Picking _Operations or SK_Picking_Warehouse groups to make changes.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop,
            MessageBoxDefaultButton.Button1);
    }

    public void MsgBoxDenyEdit()
    {
        MessageBox.Show("No edits allowed while picked complete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
    }

     Testing only
    public void MsgBoxTestErrors()
    {
        MessageBox.Show("hi");
    }
}
*/