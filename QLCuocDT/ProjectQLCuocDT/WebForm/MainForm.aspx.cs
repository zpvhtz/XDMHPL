using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public partial class testCalender : System.Web.UI.Page
{
    QLCuocDTEntities qLTinhCuocDT = new QLCuocDTEntities();
    private int idPhoneNumber = 0;
    private string nameCustomer = "";
    List<CuocGoi> listDetail;

    #region Envent
    protected void Page_Load(object sender, EventArgs e)
    {
        idPhoneNumber = int.Parse((string)Session["MaSim"]);
        nameCustomer = (string)Session["NAMECUSTOMER"];
        listDetail = qLTinhCuocDT.CuocGois.Where(x => x.MaSim == idPhoneNumber).ToList();
        //SearchByMonth(1);
        lblnameCustomer.Text = nameCustomer.ToUpper();
        Notify("");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string from = FromDate.Text;
        string to = ToDate.Text;
        if (from.Equals("") || to.Equals(""))
            return;
        SearchByDay(from, to);
    }

    //protected void btnSearchByMonth_Click(object sender, EventArgs e)
    //{
    //    string selectedValue = ddMonth.SelectedValue;
    //    SearchByMonth(int.Parse(selectedValue));
    //}

    //protected void ddMonth_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string selectedValue = ddMonth.SelectedValue;
    //    SearchByMonth(int.Parse(selectedValue));
    //}
    #endregion

    #region Method
    private void SearchByMonth(int month)
    {
        DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month - (month - 1), 1);
        List<CuocGoi> listMonthLastest = listDetail.Where(x => x.TG_BatDau >= firstDayOfMonth && x.TG_KetThuc <= DateTime.Now && x.MaSim == idPhoneNumber).OrderByDescending(x=>x.TG_BatDau).ToList();
        if (listMonthLastest.Count == 0) Notify("Không tìm thấy");
        gvThongTinSuDung.DataSource = listMonthLastest;
        gvThongTinSuDung.DataBind();
        float totalMinutes = 0;
        decimal totalPrice = 0;
        foreach (CuocGoi item in listMonthLastest)
        {
            totalMinutes += item.SoPhutSD;
            totalPrice += item.PhiCuocGoi.GetValueOrDefault();
        }
        this.totalMinutes.Text = totalMinutes.ToString() + " Phút";
        this.totalPrice.Text = totalPrice.ToString() + " VNĐ";
    }
    private void SearchByDay(string from, string to)
    {
        DateTime fromDate = DateTime.ParseExact(ChangeFormat(from), "dd/MM/yyyy", null);
        DateTime toDate = DateTime.ParseExact(ChangeFormat(to), "dd/MM/yyyy", null);
        List<CuocGoi> listBySearch = listDetail.Where(x => x.TG_BatDau >= fromDate && x.TG_KetThuc <= toDate && x.MaSim.Equals(idPhoneNumber)).OrderByDescending(x => x.TG_BatDau).ToList();
        if (listBySearch.Count == 0) Notify("Không tìm thấy");
        gvThongTinSuDung.DataSource = listBySearch;
        gvThongTinSuDung.DataBind();
        float totalMinutes = 0;
        decimal totalPrice = 0;
        foreach (CuocGoi item in listBySearch)
        {
            totalMinutes += item.SoPhutSD;
            totalPrice += item.PhiCuocGoi.GetValueOrDefault();
        }
        this.totalMinutes.Text = totalMinutes.ToString() + " Phút";
        this.totalPrice.Text = totalPrice.ToString() + " VNĐ";
    }
    private string ChangeFormat(string input)
    {
        if(!input.Equals(""))
        {
            string[] strs = input.Split('/');
            if(int.Parse(strs[0]) < 10)
            {
                strs[0] = "0" + strs[0];
            }
            if (int.Parse(strs[1]) < 10)
            {
                strs[1] = "0" + strs[1];
            }
            return strs[0] + "/" + strs[1] + "/" + strs[2];
        }
        return "";
    }
    private void Notify(string notify)
    {
        lblNotify.Text = notify;
    }

    #endregion
    
}