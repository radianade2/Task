namespace PlanningWebAgit.Models;

public class RencanaModel
{
    public int Id { get; set; }

    public int SeninAsli { get; set; }
    public int SelasaAsli { get; set; }
    public int RabuAsli { get; set; }
    public int KamisAsli { get; set; }
    public int JumatAsli { get; set; }
    public int SabtuAsli { get; set; }
    public int MingguAsli { get; set; }


    public int SeninHasil { get; set; }
    public int SelasaHasil { get; set; }
    public int RabuHasil { get; set; }
    public int KamisHasil { get; set; }
    public int JumatHasil { get; set; }
    public int SabtuHasil { get; set; }
    public int MingguHasil { get; set; }

    public DateTime TanggalProduksi { get; set; }
}