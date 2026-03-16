using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Keyless]
[Table("TBLDBALLREVENUEDB")]
public partial class Tbldballrevenuedb
{
    [Column("ID")]
    public int Id { get; set; }

    [Column("NACE_Kodu")]
    [StringLength(455)]
    public string NaceKodu { get; set; }

    [StringLength(455)]
    public string Sektor { get; set; }

    public int? Yil { get; set; }

    [Column("A-BRUT_SATISLAR")]
    public long? ABrutSatislar { get; set; }

    [Column("A-1-Yurt_Ici_Satislar")]
    public long? A1YurtIciSatislar { get; set; }

    [Column("A-2-Yurt_Disi_Satislar")]
    public long? A2YurtDisiSatislar { get; set; }

    [Column("A-3-Diger_Gelirler")]
    public long? A3DigerGelirler { get; set; }

    [Column("B-SATIS_INDIRIMLERI(-)")]
    public long? BSatisIndirimleri { get; set; }

    [Column("B-1-Satistan_Iadeler(-)")]
    public long? B1SatistanIadeler { get; set; }

    [Column("B-2-Satis_Iskontolari(-)")]
    public long? B2SatisIskontolari { get; set; }

    [Column("B-3-Diger_Indirimler(-)")]
    public long? B3DigerIndirimler { get; set; }

    [Column("C-NET_SATISLAR")]
    public long? CNetSatislar { get; set; }

    [Column("D-SATISLARIN_MALIYETI(-)")]
    public long? DSatislarinMaliyeti { get; set; }

    [Column("D-1-Satilan_Mamuller_Maliyeti(-)")]
    public long? D1SatilanMamullerMaliyeti { get; set; }

    [Column("D-2-Satilan_Ticari_Mallar_Maliyeti(-)")]
    public long? D2SatilanTicariMallarMaliyeti { get; set; }

    [Column("D-3-Satilan_Hizmet_Maliyeti_(-)")]
    public long? D3SatilanHizmetMaliyeti { get; set; }

    [Column("D-4-Diger_Satislarin_Maliyeti(-)")]
    public long? D4DigerSatislarinMaliyeti { get; set; }

    [Column("BRUT_SATIS__KARI_VEYA_ZARARI")]
    public long? BrutSatisKariVeyaZarari { get; set; }

    [Column("E-FAALIYET_GIDERLERI(-)")]
    public long? EFaaliyetGiderleri { get; set; }

    [Column("E-1-Arastirma_ve_Gelistirme_Giderleri(-)")]
    public long? E1ArastirmaVeGelistirmeGiderleri { get; set; }

    [Column("E-2-Pazarlama,Satis_ve_Dagitim_Giderleri(-)")]
    public long? E2PazarlamaSatisVeDagitimGiderleri { get; set; }

    [Column("E-3-Genel_Yonetim_Giderleri(-)")]
    public long? E3GenelYonetimGiderleri { get; set; }

    [Column("FAALIYET_KARI_VEYA_ZARARI")]
    public long? FaaliyetKariVeyaZarari { get; set; }

    [Column("F-DIGER_FAAL_OLAGAN_GELIR_VE_KARLAR")]
    public long? FDigerFaalOlaganGelirVeKarlar { get; set; }

    [Column("F-1-Istiraklerden_Temettu_Gelirleri")]
    public long? F1IstiraklerdenTemettuGelirleri { get; set; }

    [Column("F-2-Bagli_Ortakliklardan_Temettu_Gelirleri")]
    public long? F2BagliOrtakliklardanTemettuGelirleri { get; set; }

    [Column("F-3-Faiz_Gelirleri")]
    public long? F3FaizGelirleri { get; set; }

    [Column("F-4-Komisyon_Gelirleri")]
    public long? F4KomisyonGelirleri { get; set; }

    [Column("F-5-Konusu_Kalmayan_Karsiliklar")]
    public long? F5KonusuKalmayanKarsiliklar { get; set; }

    [Column("F-6-Menkul_Kiymet_Satis_Karlari")]
    public long? F6MenkulKiymetSatisKarlari { get; set; }

    [Column("F-7-Kambiyo_Karlari")]
    public long? F7KambiyoKarlari { get; set; }

    [Column("F-8-Reeskont_Faiz_Gelirleri")]
    public long? F8ReeskontFaizGelirleri { get; set; }

    [Column("F-9-Enflasyon_Duzeltmesi_Karlari")]
    public long? F9EnflasyonDuzeltmesiKarlari { get; set; }

    [Column("F-10-Diger_Olagan_Gelir_ve_Karlar")]
    public long? F10DigerOlaganGelirVeKarlar { get; set; }

    [Column("G-DIGER_FAAL_OLAGAN_GIDER_VE_ZARARLAR(-)")]
    public long? GDigerFaalOlaganGiderVeZararlar { get; set; }

    [Column("G-1-Komisyon_Giderleri(-)")]
    public long? G1KomisyonGiderleri { get; set; }

    [Column("G-2-Karsilik_Giderleri(-)")]
    public long? G2KarsilikGiderleri { get; set; }

    [Column("G-3-Menkul_Kiymet_Satis_Zararlari(-)")]
    public long? G3MenkulKiymetSatisZararlari { get; set; }

    [Column("G-4-Kambiyo_Zararlari(-)")]
    public long? G4KambiyoZararlari { get; set; }

    [Column("G-5-Reeskont_Faiz_Giderleri(-)")]
    public long? G5ReeskontFaizGiderleri { get; set; }

    [Column("G-6-Enflasyon_Duzeltmesi_Zararlari(-)")]
    public long? G6EnflasyonDuzeltmesiZararlari { get; set; }

    [Column("G-7-Diger_Olagan_Gider_ve_Zararlar(-)")]
    public long? G7DigerOlaganGiderVeZararlar { get; set; }

    [Column("H-FINANSMAN_GIDERLERI(-)")]
    public long? HFinansmanGiderleri { get; set; }

    [Column("H-1-Kisa_Vadeli_Borclanma_Giderleri(-)")]
    public long? H1KisaVadeliBorclanmaGiderleri { get; set; }

    [Column("H-2-Uzun_Vadeli_Borclanma_Giderleri(-)")]
    public long? H2UzunVadeliBorclanmaGiderleri { get; set; }

    [Column("OLAGAN_KAR_VEYA_ZARAR")]
    public long? OlaganKarVeyaZarar { get; set; }

    [Column("I-OLAGANDISI_GELIR_VE_KARLAR")]
    public long? IOlagandisiGelirVeKarlar { get; set; }

    [Column("I-1-Onceki_Donem_Gelir_ve_Karlari")]
    public long? I1OncekiDonemGelirVeKarlari { get; set; }

    [Column("I-2-Diger_Olagandisi_Gelir_ve_Karlar")]
    public long? I2DigerOlagandisiGelirVeKarlar { get; set; }

    [Column("J-OLAGANDISI_GIDER_VE_ZARARLAR(-)")]
    public long? JOlagandisiGiderVeZararlar { get; set; }

    [Column("J-1-Calismayan_Kisim_Gider_ve_Zarar(-)")]
    public long? J1CalismayanKisimGiderVeZarar { get; set; }

    [Column("J-2-Onceki_Donem_Gider_ve_Zararlari(-)")]
    public long? J2OncekiDonemGiderVeZararlari { get; set; }

    [Column("J-3-Diger_Olagandisi_Gider_ve_Zarar(-)")]
    public long? J3DigerOlagandisiGiderVeZarar { get; set; }

    [Column("DONEM_KAR_VEYA_ZARARI")]
    public long? DonemKarVeyaZarari { get; set; }

    [Column("K-DONEM_KARI_VERGI/DIG_YASAL_YUK_KARS(-)")]
    public long? KDonemKariVergiDigYasalYukKars { get; set; }

    [Column("DONEM_NET_KAR_VEYA_ZARARI")]
    public long? DonemNetKarVeyaZarari { get; set; }
}
