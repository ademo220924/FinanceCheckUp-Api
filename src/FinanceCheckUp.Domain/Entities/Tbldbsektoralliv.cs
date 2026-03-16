using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Keyless]
[Table("TBLDBSEKTORALLIV")]
public partial class Tbldbsektoralliv
{
    [Column("ID")]
    public int Id { get; set; }

    [Column("NACE_Kodu")]
    [StringLength(455)]
    public string NaceKodu { get; set; }

    [StringLength(455)]
    public string Sektor { get; set; }

    public int? Yil { get; set; }

    [Column("AKTIF_TOPLAMI")]
    public long? AktifToplami { get; set; }

    [Column("I_Donen_Varliklar")]
    public long? IDonenVarliklar { get; set; }

    [Column("I_A_Hazir_Degerler_(dov)")]
    public long? IAHazirDegerlerDov { get; set; }

    [Column("I_A_1_Kasa_(dov)")]
    public long? IA1KasaDov { get; set; }

    [Column("I_A_2_Alinan_Cekler_(dov)")]
    public long? IA2AlinanCeklerDov { get; set; }

    [Column("I_A_3_Bankalar_(dov)")]
    public long? IA3BankalarDov { get; set; }

    [Column("I_A_4_Verilen_Cekler_ve_Odeme_Emirleri_(-)_(dov)")]
    public long? IA4VerilenCeklerVeOdemeEmirleriDov { get; set; }

    [Column("I_A_5_Diger_Hazir_Degerler_(dov)")]
    public long? IA5DigerHazirDegerlerDov { get; set; }

    [Column("I_B_Menkul_Kiymetler_(dov)")]
    public long? IBMenkulKiymetlerDov { get; set; }

    [Column("I_B_1_Hisse_Senetleri_(dov)")]
    public long? IB1HisseSenetleriDov { get; set; }

    [Column("I_B_2_Ozel_Kesim_Tahvil,_Senet_ve_Bonolari_(dov)")]
    public long? IB2OzelKesimTahvilSenetVeBonolariDov { get; set; }

    [Column("I_B_3_Kamu_Kesimi_Tahvil,_Senet_ve_Bonolari_(dov)")]
    public long? IB3KamuKesimiTahvilSenetVeBonolariDov { get; set; }

    [Column("I_B_4_Diger_Menkul_Kiymetler_(dov)")]
    public long? IB4DigerMenkulKiymetlerDov { get; set; }

    [Column("I_B_5_Menkul_Kiymetler_Deger_Dusuklugu_Karsiligi_(-)_(dov)")]
    public long? IB5MenkulKiymetlerDegerDusukluguKarsiligiDov { get; set; }

    [Column("I_C_Ticari_Alacaklar_(dov)")]
    public long? ICTicariAlacaklarDov { get; set; }

    [Column("I_C_1_Alicilar_(dov)")]
    public long? IC1AlicilarDov { get; set; }

    [Column("I_C_2_Alacak_Senetleri_(dov)")]
    public long? IC2AlacakSenetleriDov { get; set; }

    [Column("I_C_3_Alacak_Senetleri_Reeskontu_(-)_(dov)")]
    public long? IC3AlacakSenetleriReeskontuDov { get; set; }

    [Column("I_C_4_Verilen_Depozito_ve_Teminatlar_(dov)")]
    public long? IC4VerilenDepozitoVeTeminatlarDov { get; set; }

    [Column("I_C_5_Kazanilmamis_Finansal_Kiralama_Faiz_Gelirleri_(-)_(dov)")]
    public long? IC5KazanilmamisFinansalKiralamaFaizGelirleriDov { get; set; }

    [Column("I_C_6_Diger_Ticari_Alacaklar_(dov)")]
    public long? IC6DigerTicariAlacaklarDov { get; set; }

    [Column("I_C_7_Supheli_Ticari_Alacaklar_(dov)")]
    public long? IC7SupheliTicariAlacaklarDov { get; set; }

    [Column("I_C_8_Supheli_Ticari_Alacaklar_Karsiligi_(-)_(dov)")]
    public long? IC8SupheliTicariAlacaklarKarsiligiDov { get; set; }

    [Column("I_D_Diger_Alacaklar_(dov)")]
    public long? IDDigerAlacaklarDov { get; set; }

    [Column("I_D_1_Ortaklardan_Alacaklar_(dov)")]
    public long? ID1OrtaklardanAlacaklarDov { get; set; }

    [Column("I_D_2_Istiraklerden_Alacaklar_(dov)")]
    public long? ID2IstiraklerdenAlacaklarDov { get; set; }

    [Column("I_D_3_Bagli_Ortakliklardan_Alacaklar_(dov)")]
    public long? ID3BagliOrtakliklardanAlacaklarDov { get; set; }

    [Column("I_D_4_Personelden_Alacaklar_(dov)")]
    public long? ID4PersoneldenAlacaklarDov { get; set; }

    [Column("I_D_5_Diger_Cesitli_Alacaklar_(dov)")]
    public long? ID5DigerCesitliAlacaklarDov { get; set; }

    [Column("I_D_6_Diger_Alacak_Senetleri_Reeskontu_(-)_(dov)")]
    public long? ID6DigerAlacakSenetleriReeskontuDov { get; set; }

    [Column("I_D_7_Supheli_Diger_Alacaklar_(dov)")]
    public long? ID7SupheliDigerAlacaklarDov { get; set; }

    [Column("I_D_8_Supheli_Diger_Alacaklar_Karsiligi_(-)_(dov)")]
    public long? ID8SupheliDigerAlacaklarKarsiligiDov { get; set; }

    [Column("I_E_Stoklar_(dov)")]
    public long? IEStoklarDov { get; set; }

    [Column("I_E_1_Ilk_Madde_ve_Malzeme_(dov)")]
    public long? IE1IlkMaddeVeMalzemeDov { get; set; }

    [Column("I_E_2_Yari_Mamuller_-_Uretim_(dov)")]
    public long? IE2YariMamullerUretimDov { get; set; }

    [Column("I_E_3_Mamuller_(dov)")]
    public long? IE3MamullerDov { get; set; }

    [Column("I_E_4_Ticari_Mallar_(dov)")]
    public long? IE4TicariMallarDov { get; set; }

    [Column("I_E_5_Diger_Stoklar_(dov)")]
    public long? IE5DigerStoklarDov { get; set; }

    [Column("I_E_6_Stok_Deger_Dusuklugu_Karsiligi_(-)_(dov)")]
    public long? IE6StokDegerDusukluguKarsiligiDov { get; set; }

    [Column("I_E_7_Verilen_Siparis_Avanslari_(dov)")]
    public long? IE7VerilenSiparisAvanslariDov { get; set; }

    [Column("I_F_Yillara_Yaygin_Insaat_ve_Onarim_Maliyetleri_(dov)")]
    public long? IFYillaraYayginInsaatVeOnarimMaliyetleriDov { get; set; }

    [Column("I_F_1._Yillara_Yaygin_Insaat_ve_Onarim_Maliyetleri_(dov)")]
    public long? IF1YillaraYayginInsaatVeOnarimMaliyetleriDov { get; set; }

    [Column("I_F_2._Yillara_Yaygin_Insaat_Enflasyon_Duzeltme_Hesabi_(dov)")]
    public long? IF2YillaraYayginInsaatEnflasyonDuzeltmeHesabiDov { get; set; }

    [Column("I_F_3._Taseronlara_Verilen_Avanslar_(dov)")]
    public long? IF3TaseronlaraVerilenAvanslarDov { get; set; }

    [Column("I_G_Gelecek_Aylara_Ait_Giderler_ve_Gelir_Tahakkuklari_(dov)")]
    public long? IGGelecekAylaraAitGiderlerVeGelirTahakkuklariDov { get; set; }

    [Column("I_G_1._Gelecek_Aylara_Ait_Giderler_(dov)")]
    public long? IG1GelecekAylaraAitGiderlerDov { get; set; }

    [Column("I_G_2._Gelir_Tahakkuklari_(dov)")]
    public long? IG2GelirTahakkuklariDov { get; set; }

    [Column("I_H_Diger_Donen_Varliklar_(dov)")]
    public long? IHDigerDonenVarliklarDov { get; set; }

    [Column("I_H_1_Devreden_KDV_(dov)")]
    public long? IH1DevredenKdvDov { get; set; }

    [Column("I_H_2_Indirilecek_KDV_(dov)")]
    public long? IH2IndirilecekKdvDov { get; set; }

    [Column("I_H_3_Diger_KDV_(dov)")]
    public long? IH3DigerKdvDov { get; set; }

    [Column("I_H_4_Pesin_Odenen_Vergiler_ve_Fonlar_(dov)")]
    public long? IH4PesinOdenenVergilerVeFonlarDov { get; set; }

    [Column("I_H_5_Is_Avanslari_(dov)")]
    public long? IH5IsAvanslariDov { get; set; }

    [Column("I_H_6_Personel_Avanslari_(dov)")]
    public long? IH6PersonelAvanslariDov { get; set; }

    [Column("I_H_7_Sayim_ve_Tesellum_Noksanlari_(dov)")]
    public long? IH7SayimVeTesellumNoksanlariDov { get; set; }

    [Column("I_H_8_Diger_Cesitli_Donen_Varliklar_(dov)")]
    public long? IH8DigerCesitliDonenVarliklarDov { get; set; }

    [Column("I_H_9_Diger_Cesitli_Donen_Varliklar_Karsiligi_(-)_(dov)")]
    public long? IH9DigerCesitliDonenVarliklarKarsiligiDov { get; set; }

    [Column("II_DURAN_VARLIKLAR")]
    public long? IiDuranVarliklar { get; set; }

    [Column("II_A_Ticari_Alacaklar_(duv)")]
    public long? IiATicariAlacaklarDuv { get; set; }

    [Column("II_A_1_Alicilar_(duv)")]
    public long? IiA1AlicilarDuv { get; set; }

    [Column("II_A_2_Alacak_Senetleri_(duv)")]
    public long? IiA2AlacakSenetleriDuv { get; set; }

    [Column("II_A_3_Alacak_Senetleri_Reeskontu_(-)_(duv)")]
    public long? IiA3AlacakSenetleriReeskontuDuv { get; set; }

    [Column("II_A_4_Kazanilmamis_Finansal_Kiralama_Faiz_Gelirleri_(-)_(duv)")]
    public long? IiA4KazanilmamisFinansalKiralamaFaizGelirleriDuv { get; set; }

    [Column("II_A_5_Verilen_Depozito_ve_Teminatlar_(duv)")]
    public long? IiA5VerilenDepozitoVeTeminatlarDuv { get; set; }

    [Column("II_A_6_Supheli_Alacaklar_Karsiligi_(-)_(duv)")]
    public long? IiA6SupheliAlacaklarKarsiligiDuv { get; set; }

    [Column("II_B_Diger_Alacaklar_(duv)")]
    public long? IiBDigerAlacaklarDuv { get; set; }

    [Column("II_B_1_Ortaklardan_Alacaklar_(duv)")]
    public long? IiB1OrtaklardanAlacaklarDuv { get; set; }

    [Column("II_B_2_Istiraklerden_Alacaklar_(duv)")]
    public long? IiB2IstiraklerdenAlacaklarDuv { get; set; }

    [Column("II_B_3_Bagli_Ortakliklardan_Alacaklar_(duv)")]
    public long? IiB3BagliOrtakliklardanAlacaklarDuv { get; set; }

    [Column("II_B_4_Personelden_Alacaklar_(duv)")]
    public long? IiB4PersoneldenAlacaklarDuv { get; set; }

    [Column("II_B_5_Diger_Cesitli_Alacaklar_(duv)")]
    public long? IiB5DigerCesitliAlacaklarDuv { get; set; }

    [Column("II_B_6_Diger_Alacak_Senetleri_Reeskontu_(-)_(duv)")]
    public long? IiB6DigerAlacakSenetleriReeskontuDuv { get; set; }

    [Column("II_B_7_Supheli_Diger_Alacaklar_Karsiligi_(-)_(duv)")]
    public long? IiB7SupheliDigerAlacaklarKarsiligiDuv { get; set; }

    [Column("II_C_Mali_Duran_Varliklar_(duv)")]
    public long? IiCMaliDuranVarliklarDuv { get; set; }

    [Column("II_C_1_Bagli_Menkul_Kiymetler_(duv)")]
    public long? IiC1BagliMenkulKiymetlerDuv { get; set; }

    [Column("II_C_2_Bagli_Menkul_Kiymetler_Deger_Dusuklugu_Karsiligi_(-)_(duv)")]
    public long? IiC2BagliMenkulKiymetlerDegerDusukluguKarsiligiDuv { get; set; }

    [Column("II_C_3_Istirakler_(duv)")]
    public long? IiC3IstiraklerDuv { get; set; }

    [Column("II_C_4_Istiraklere_Sermaye_Taahhutleri_(-)_(duv)")]
    public long? IiC4IstiraklereSermayeTaahhutleriDuv { get; set; }

    [Column("II_C_5_Istirakler_Sermaye_Paylari_Deger_Dusuklugu_Karsiligi_(-)_(duv)")]
    public long? IiC5IstiraklerSermayePaylariDegerDusukluguKarsiligiDuv { get; set; }

    [Column("II_C_6_Bagli_Ortakliklar_(duv)")]
    public long? IiC6BagliOrtakliklarDuv { get; set; }

    [Column("II_C_7_Bagli_Ortakliklar_Sermaye_Taahutleri_(-)_(duv)")]
    public long? IiC7BagliOrtakliklarSermayeTaahutleriDuv { get; set; }

    [Column("II_C_8_Bagli_Ortakliklar_Sermaye_Paylari_Deger_Dusuklugu_Karsiligi_(-)_(duv)")]
    public long? IiC8BagliOrtakliklarSermayePaylariDegerDusukluguKarsiligiDuv { get; set; }

    [Column("II_C_9_Diger_Mali_Duran_Varliklar_(duv)")]
    public long? IiC9DigerMaliDuranVarliklarDuv { get; set; }

    [Column("II_C_10_Diger_Mali_Duran_Varliklar_Karsiligi_(-)_(duv)")]
    public long? IiC10DigerMaliDuranVarliklarKarsiligiDuv { get; set; }

    [Column("II_D_Maddi_Duran_Varliklar_(duv)")]
    public long? IiDMaddiDuranVarliklarDuv { get; set; }

    [Column("II_D_1_Arazi_ve_Arsalar_(duv)")]
    public long? IiD1AraziVeArsalarDuv { get; set; }

    [Column("II_D_2_Yer_Alti_ve_Yer_Ustu_Duzenleri_(duv)")]
    public long? IiD2YerAltiVeYerUstuDuzenleriDuv { get; set; }

    [Column("II_D_3_Binalar_(duv)")]
    public long? IiD3BinalarDuv { get; set; }

    [Column("II_D_4_Tesis,_Makina_ve_Cihazlar_(duv)")]
    public long? IiD4TesisMakinaVeCihazlarDuv { get; set; }

    [Column("II_D_5_Tasitlar_(duv)")]
    public long? IiD5TasitlarDuv { get; set; }

    [Column("II_D_6_Demirbaslar_(duv)")]
    public long? IiD6DemirbaslarDuv { get; set; }

    [Column("II_D_7_Diger_Maddi_Duran_Varliklar_(duv)")]
    public long? IiD7DigerMaddiDuranVarliklarDuv { get; set; }

    [Column("II_D_8_Birikmis_Amortismanlar_(-)_(duv1)")]
    public long? IiD8BirikmisAmortismanlarDuv1 { get; set; }

    [Column("II_D_9_Yapilmakta_Olan_Yatirimlar_(duv)")]
    public long? IiD9YapilmaktaOlanYatirimlarDuv { get; set; }

    [Column("II_D_10_Verilen_Avanslar_(duv)")]
    public long? IiD10VerilenAvanslarDuv { get; set; }

    [Column("II_E_Maddi_Olmayan_Duran_Varliklar_(duv)")]
    public long? IiEMaddiOlmayanDuranVarliklarDuv { get; set; }

    [Column("II_E_1_Haklar_(duv)")]
    public long? IiE1HaklarDuv { get; set; }

    [Column("II_E_2_Serefiye_(duv)")]
    public long? IiE2SerefiyeDuv { get; set; }

    [Column("II_E_3_Kurulus_ve_Orgutlenme_Giderleri_(duv)")]
    public long? IiE3KurulusVeOrgutlenmeGiderleriDuv { get; set; }

    [Column("II_E_4_Arastirma_ve_Gelistirme_Giderleri_(duv)")]
    public long? IiE4ArastirmaVeGelistirmeGiderleriDuv { get; set; }

    [Column("II_E_5_Ozel_Maliyetler_(duv)")]
    public long? IiE5OzelMaliyetlerDuv { get; set; }

    [Column("II_E_6_Diger_Maddi_Olmayan_Duran_Varliklar_(duv)")]
    public long? IiE6DigerMaddiOlmayanDuranVarliklarDuv { get; set; }

    [Column("II_E_7_Birikmis_Amortismanlar_(-)_(duv)")]
    public long? IiE7BirikmisAmortismanlarDuv { get; set; }

    [Column("II_E_8_Verilen_Avanslar_(duv)")]
    public long? IiE8VerilenAvanslarDuv { get; set; }

    [Column("II_F_Ozel_Tukenmeye_Tabi_Varliklar_(duv)")]
    public long? IiFOzelTukenmeyeTabiVarliklarDuv { get; set; }

    [Column("II_F_1_Arama_Giderleri_(duv)")]
    public long? IiF1AramaGiderleriDuv { get; set; }

    [Column("II_F_2_Hazirlik_ve_Gelistirme_Giderleri_(duv)")]
    public long? IiF2HazirlikVeGelistirmeGiderleriDuv { get; set; }

    [Column("II_F_3_Diger_Ozel_Tukenmeye_Tabi_Varliklar_(duv)")]
    public long? IiF3DigerOzelTukenmeyeTabiVarliklarDuv { get; set; }

    [Column("II_F_4_Birikmis_Tukenme_Paylari_(-)_(duv)")]
    public long? IiF4BirikmisTukenmePaylariDuv { get; set; }

    [Column("II_F_5_Verilen_Avanslar_(duv)")]
    public long? IiF5VerilenAvanslarDuv { get; set; }

    [Column("II_G_Gelecek_Yillara_Ait_Giderler_ve_Gelir_Tahakkuklari_(duv)")]
    public long? IiGGelecekYillaraAitGiderlerVeGelirTahakkuklariDuv { get; set; }

    [Column("II_G_1_Gelecek_Yillara_Ait_Giderler_(duv)")]
    public long? IiG1GelecekYillaraAitGiderlerDuv { get; set; }

    [Column("II_G_2_Gelir_Tahakkuklari_(duv)")]
    public long? IiG2GelirTahakkuklariDuv { get; set; }

    [Column("II_H_Diger_Duran_Varliklar_(duv)")]
    public long? IiHDigerDuranVarliklarDuv { get; set; }

    [Column("II_H_1_Gelecek_Yillarda_Indirilecek_KDV_(duv)")]
    public long? IiH1GelecekYillardaIndirilecekKdvDuv { get; set; }

    [Column("II_H_2_Diger_KDV_(duv)")]
    public long? IiH2DigerKdvDuv { get; set; }

    [Column("II_H_3_Gelecek_Yillar_Ihtiyaci_Stoklar_(duv)")]
    public long? IiH3GelecekYillarIhtiyaciStoklarDuv { get; set; }

    [Column("II_H_4_Elden_Cikarilacak_Stoklar_ve_Maddi_Duran_Varliklar_(duv)")]
    public long? IiH4EldenCikarilacakStoklarVeMaddiDuranVarliklarDuv { get; set; }

    [Column("II_H_5_Pesin_Odenen_Vergiler_ve_Fonlar_(duv)")]
    public long? IiH5PesinOdenenVergilerVeFonlarDuv { get; set; }

    [Column("II_H_6_Diger_Cesitli_Duran_Varliklar_(duv)")]
    public long? IiH6DigerCesitliDuranVarliklarDuv { get; set; }

    [Column("II_H_7_Stok_Deger_Dusuklugu_Karsiligi_(-)_(duv)")]
    public long? IiH7StokDegerDusukluguKarsiligiDuv { get; set; }

    [Column("II_H_8_Birikmis_Amortismanlar_(-)_(duv2)")]
    public long? IiH8BirikmisAmortismanlarDuv2 { get; set; }

    [Column("II_H_9_Gecici_Hesap_(duv)")]
    public long? IiH9GeciciHesapDuv { get; set; }

    [Column("II_PASIF_TOPLAMI")]
    public long? IiPasifToplami { get; set; }

    [Column("III_Kisa_Vadeli_Yabanci_Kaynaklar")]
    public long? IiiKisaVadeliYabanciKaynaklar { get; set; }

    [Column("III_A_Mali_Borclar_(kv)")]
    public long? IiiAMaliBorclarKv { get; set; }

    [Column("III_A_1_Banka_Kredileri_(kv)")]
    public long? IiiA1BankaKredileriKv { get; set; }

    [Column("III_A_2_Finansal_Kiralama_Islemlerinden_Borclar_(kv)")]
    public long? IiiA2FinansalKiralamaIslemlerindenBorclarKv { get; set; }

    [Column("III_A_3_Ertelenmis_Finansal_Kiralama_Borclanma_Maliyetleri_(-)_(kv)")]
    public long? IiiA3ErtelenmisFinansalKiralamaBorclanmaMaliyetleriKv { get; set; }

    [Column("III_A_4_Uzun_Vadeli_Kredilerin_Anapara_Taksitleri_ve_Faizleri_(kv)")]
    public long? IiiA4UzunVadeliKredilerinAnaparaTaksitleriVeFaizleriKv { get; set; }

    [Column("III_A_5_Tahvil,_Anapara,_Borc,_Taksit_ve_Faizleri_(kv)")]
    public long? IiiA5TahvilAnaparaBorcTaksitVeFaizleriKv { get; set; }

    [Column("III_A_6_Cikarilmis_Bonolar_ve_Senetler_(kv)")]
    public long? IiiA6CikarilmisBonolarVeSenetlerKv { get; set; }

    [Column("III_A_7_Cikarilmis_Diger_Menkul_Kiymetler_(kv)")]
    public long? IiiA7CikarilmisDigerMenkulKiymetlerKv { get; set; }

    [Column("III_A_8_Menkul_Kiymetler_Ihrac_Farki_(-)_(kv)")]
    public long? IiiA8MenkulKiymetlerIhracFarkiKv { get; set; }

    [Column("III_A_9_Diger_Mali_Borclar_(kv)")]
    public long? IiiA9DigerMaliBorclarKv { get; set; }

    [Column("III_B_Ticari_Borclar_(kv)")]
    public long? IiiBTicariBorclarKv { get; set; }

    [Column("III_B_1_Saticilar_(kv)")]
    public long? IiiB1SaticilarKv { get; set; }

    [Column("III_B_2_Borc_Senetleri_(kv)")]
    public long? IiiB2BorcSenetleriKv { get; set; }

    [Column("III_B_3_Borc_Senetleri_Reeskontu_(-)_(kv)")]
    public long? IiiB3BorcSenetleriReeskontuKv { get; set; }

    [Column("III_B_4_Alinan_Depozito_ve_Teminatlar_(kv)")]
    public long? IiiB4AlinanDepozitoVeTeminatlarKv { get; set; }

    [Column("III_B_5_Diger_Ticari_Borclar_(kv)")]
    public long? IiiB5DigerTicariBorclarKv { get; set; }

    [Column("III_C_Diger_Borclar_(kv)")]
    public long? IiiCDigerBorclarKv { get; set; }

    [Column("III_C_1_Ortaklara_Borclar_(kv)")]
    public long? IiiC1OrtaklaraBorclarKv { get; set; }

    [Column("III_C_2_Istiraklere_Borclar_(kv)")]
    public long? IiiC2IstiraklereBorclarKv { get; set; }

    [Column("III_C_3_Bagli_Ortakliklara_Borclar_(kv)")]
    public long? IiiC3BagliOrtakliklaraBorclarKv { get; set; }

    [Column("III_C_4_Personele_Borclar_(kv)")]
    public long? IiiC4PersoneleBorclarKv { get; set; }

    [Column("III_C_5_Diger_Cesitli_Borclar_(kv)")]
    public long? IiiC5DigerCesitliBorclarKv { get; set; }

    [Column("III_C_6_Diger_Borc_Senetleri_Reeskontu_(-)_(kv)")]
    public long? IiiC6DigerBorcSenetleriReeskontuKv { get; set; }

    [Column("III_D_Alinan_Avanslar_(kv)")]
    public long? IiiDAlinanAvanslarKv { get; set; }

    [Column("III_D_1_Alinan_Siparis_Avanslari_(kv)")]
    public long? IiiD1AlinanSiparisAvanslariKv { get; set; }

    [Column("III_D_2_Alinan_Diger_Avanslar_(kv)")]
    public long? IiiD2AlinanDigerAvanslarKv { get; set; }

    [Column("III_E_Yillara_Yaygin_Insaat_ve_Onarim_Hakedisleri_(kv)")]
    public long? IiiEYillaraYayginInsaatVeOnarimHakedisleriKv { get; set; }

    [Column("III_E_1_Yillara_Yaygin_Insaat_ve_Onarim_Hakedis_Bedelleri_(kv)")]
    public long? IiiE1YillaraYayginInsaatVeOnarimHakedisBedelleriKv { get; set; }

    [Column("III_E_2_Yillara_Yaygin_Insaat_Enflasyon_Duzeltme_Hesabi_(kv)")]
    public long? IiiE2YillaraYayginInsaatEnflasyonDuzeltmeHesabiKv { get; set; }

    [Column("III_F_Odenecek_Vergi_ve_Diger_Yukumlulukler_(kv)")]
    public long? IiiFOdenecekVergiVeDigerYukumluluklerKv { get; set; }

    [Column("III_F_1_Odenecek_Vergi_ve_Fonlar_(kv)")]
    public long? IiiF1OdenecekVergiVeFonlarKv { get; set; }

    [Column("III_F_2_Odenecek_Sosyal_Guvenlik_Kesintileri_(kv)")]
    public long? IiiF2OdenecekSosyalGuvenlikKesintileriKv { get; set; }

    [Column("III_F_3_Vadesi_Gecmis_Ertelenmis_veya_Taksitlendirilmis_Vergi_ve_Diger_Yukumlulukler_(kv)")]
    public long? IiiF3VadesiGecmisErtelenmisVeyaTaksitlendirilmisVergiVeDigerYukumluluklerKv { get; set; }

    [Column("III_F_4_Odenecek_Diger_Yukumlulukler_(kv)")]
    public long? IiiF4OdenecekDigerYukumluluklerKv { get; set; }

    [Column("III_G_Borc_ve_Gider_Karsiliklari_(kv)")]
    public long? IiiGBorcVeGiderKarsiliklariKv { get; set; }

    [Column("III_G_1_Donem_Kari_Vergi_ve_Diger_Yasal_Yukumluluk_Karsiliklari_(kv)")]
    public long? IiiG1DonemKariVergiVeDigerYasalYukumlulukKarsiliklariKv { get; set; }

    [Column("III_G_2_Donem_Karinin_Pesin_Odenen_Vergi_ve_Diger_Yukumlulukleri_(-)_(kv)")]
    public long? IiiG2DonemKarininPesinOdenenVergiVeDigerYukumlulukleriKv { get; set; }

    [Column("III_G_3_Kidem_Tazminati_Karsiligi_(kv)")]
    public long? IiiG3KidemTazminatiKarsiligiKv { get; set; }

    [Column("III_G_4_Maliyet_Giderleri_Karsiligi_(kv)")]
    public long? IiiG4MaliyetGiderleriKarsiligiKv { get; set; }

    [Column("III_G_5_Diger_Borc_ve_Gider_Karsiliklari_(kv)")]
    public long? IiiG5DigerBorcVeGiderKarsiliklariKv { get; set; }

    [Column("III_H_Gelecek_Aylara_Ait_Gelirler_ve_Gider_Tahakkuklari_(kv)")]
    public long? IiiHGelecekAylaraAitGelirlerVeGiderTahakkuklariKv { get; set; }

    [Column("III_H_1_Gelecek_Aylara_Ait_Gelirler_(kv)")]
    public long? IiiH1GelecekAylaraAitGelirlerKv { get; set; }

    [Column("III_H_2_Gider_Tahakkuklari_(kv)")]
    public long? IiiH2GiderTahakkuklariKv { get; set; }

    [Column("III_I_Diger_Kisa_Vadeli_Yabanci_Kaynaklar_(kv)")]
    public long? IiiIDigerKisaVadeliYabanciKaynaklarKv { get; set; }

    [Column("III_I_1_Hesaplanan_KDV_(kv)")]
    public long? IiiI1HesaplananKdvKv { get; set; }

    [Column("III_I_2_Diger_KDV_(kv)")]
    public long? IiiI2DigerKdvKv { get; set; }

    [Column("III_I_3_Merkez_ve_Subeler_Cari_Hesabi_(kv)")]
    public long? IiiI3MerkezVeSubelerCariHesabiKv { get; set; }

    [Column("III_I_4_Sayim_ve_Tesellum_Fazlalari_(kv)")]
    public long? IiiI4SayimVeTesellumFazlalariKv { get; set; }

    [Column("III_I_5_Diger_Cesitli_Yabanci_Kaynaklar_(kv)")]
    public long? IiiI5DigerCesitliYabanciKaynaklarKv { get; set; }

    [Column("IV_Uzun_Vadeli_Yabanci_Kaynaklar")]
    public long? IvUzunVadeliYabanciKaynaklar { get; set; }

    [Column("IV_A_Mali_Borclar_(uv)")]
    public long? IvAMaliBorclarUv { get; set; }

    [Column("IV_A_1_Banka_Kredileri_(uv)")]
    public long? IvA1BankaKredileriUv { get; set; }

    [Column("IV_A_2_Finansal_Kiralama_Islemlerinden_Borclar_(uv)")]
    public long? IvA2FinansalKiralamaIslemlerindenBorclarUv { get; set; }

    [Column("IV_A_3_Ertelenmis_Finansal_Kiralama_Borclanma_Maliyetleri_(-)_(uv)")]
    public long? IvA3ErtelenmisFinansalKiralamaBorclanmaMaliyetleriUv { get; set; }

    [Column("IV_A_4_Cikarilmis_Tahviller_(uv)")]
    public long? IvA4CikarilmisTahvillerUv { get; set; }

    [Column("IV_A_5_Cikarilmis_Diger_Menkul_Kiymetler_(uv)")]
    public long? IvA5CikarilmisDigerMenkulKiymetlerUv { get; set; }

    [Column("IV_A_6_Menkul_Kiymetler_Ihrac_Farki_(-)_(uv)")]
    public long? IvA6MenkulKiymetlerIhracFarkiUv { get; set; }

    [Column("IV_A_7_Diger_Mali_Borclar_(uv)")]
    public long? IvA7DigerMaliBorclarUv { get; set; }

    [Column("IV_B_Ticari_Borclar_(uv)")]
    public long? IvBTicariBorclarUv { get; set; }

    [Column("IV_B_1_Saticilar_(uv)")]
    public long? IvB1SaticilarUv { get; set; }

    [Column("IV_B_2_Borc_Senetleri_(uv)")]
    public long? IvB2BorcSenetleriUv { get; set; }

    [Column("IV_B_3_Borc_Senetleri_Reeskontu_(-)_(uv)")]
    public long? IvB3BorcSenetleriReeskontuUv { get; set; }

    [Column("IV_B_4_Alinan_Depozito_ve_Teminatlar_(uv)")]
    public long? IvB4AlinanDepozitoVeTeminatlarUv { get; set; }

    [Column("IV_B_5_Diger_Ticari_Borclar_(uv)")]
    public long? IvB5DigerTicariBorclarUv { get; set; }

    [Column("IV_C_Diger_Borclar_(uv)")]
    public long? IvCDigerBorclarUv { get; set; }

    [Column("IV_C_1_Ortaklara_Borclar_(uv)")]
    public long? IvC1OrtaklaraBorclarUv { get; set; }

    [Column("IV_C_2_Istiraklere_Borclar_(uv)")]
    public long? IvC2IstiraklereBorclarUv { get; set; }

    [Column("IV_C_3_Bagli_Ortakliklara_Borclar_(uv)")]
    public long? IvC3BagliOrtakliklaraBorclarUv { get; set; }

    [Column("IV_C_4_Diger_Cesitli_Borclar_(uv)")]
    public long? IvC4DigerCesitliBorclarUv { get; set; }

    [Column("IV_C_5_Diger_Borc_Senetleri_Reeskontu_(-)_(uv)")]
    public long? IvC5DigerBorcSenetleriReeskontuUv { get; set; }

    [Column("IV_C_6_Kamuya_Olan_Ertelenmis_veya_Taksitlendirilmis_Borclar_(uv)")]
    public long? IvC6KamuyaOlanErtelenmisVeyaTaksitlendirilmisBorclarUv { get; set; }

    [Column("IV_D_Alinan_Avanslar_(uv)")]
    public long? IvDAlinanAvanslarUv { get; set; }

    [Column("IV_D_1_Alinan_Siparis_Avanslari_(uv)")]
    public long? IvD1AlinanSiparisAvanslariUv { get; set; }

    [Column("IV_D_2_Alinan_Diger_Avanslar_(uv)")]
    public long? IvD2AlinanDigerAvanslarUv { get; set; }

    [Column("IV_E_Borc_ve_Gider_Karsiliklari_(uv)")]
    public long? IvEBorcVeGiderKarsiliklariUv { get; set; }

    [Column("IV_E_1_Kidem_Tazminati_Karsiliklari_(uv)")]
    public long? IvE1KidemTazminatiKarsiliklariUv { get; set; }

    [Column("IV_E_2_Diger_Borc_ve_Gider_Karsiliklari_(uv)")]
    public long? IvE2DigerBorcVeGiderKarsiliklariUv { get; set; }

    [Column("IV_F_Gelecek_Yillara_Ait_Gelirler_ve_Gider_Tahakkuklari_(uv)")]
    public long? IvFGelecekYillaraAitGelirlerVeGiderTahakkuklariUv { get; set; }

    [Column("IV_F_1_Gelecek_Yillara_Ait_Gelirler_(uv)")]
    public long? IvF1GelecekYillaraAitGelirlerUv { get; set; }

    [Column("IV_F_2_Gider_Tahakkuklari_(uv)")]
    public long? IvF2GiderTahakkuklariUv { get; set; }

    [Column("IV_G_Diger_Uzun_Vadeli_Yabanci_Kaynaklar_(uv)")]
    public long? IvGDigerUzunVadeliYabanciKaynaklarUv { get; set; }

    [Column("IV_G_1_Gelecek_Yillara_Ertlenen_veya_Terkin_Edilen_KDV_(uv)")]
    public long? IvG1GelecekYillaraErtlenenVeyaTerkinEdilenKdvUv { get; set; }

    [Column("IV_G_2_Tesise_Katilma_Paylari_(uv)")]
    public long? IvG2TesiseKatilmaPaylariUv { get; set; }

    [Column("IV_G_3_Diger_Cesitli_Uzun_Vadeli_Yabanci_Kaynaklar_Toplami_(uv)")]
    public long? IvG3DigerCesitliUzunVadeliYabanciKaynaklarToplamiUv { get; set; }

    [Column("V_Oz_Kaynaklar")]
    public long? VOzKaynaklar { get; set; }

    [Column("V_A_Odenmis_Sermaye")]
    public long? VAOdenmisSermaye { get; set; }

    [Column("V_A_1._Sermaye")]
    public long? VA1Sermaye { get; set; }

    [Column("V_A_2._Odenmemis_Sermaye_(-)")]
    public long? VA2OdenmemisSermaye { get; set; }

    [Column("V_A_3._Sermaye_Duzeltmesi_Olumlu_Farklari")]
    public long? VA3SermayeDuzeltmesiOlumluFarklari { get; set; }

    [Column("V_A_4._Sermaye_Duzeltmesi_Olumsuz_Farklari(-)")]
    public long? VA4SermayeDuzeltmesiOlumsuzFarklari { get; set; }

    [Column("V_B_Sermaye_Yedekleri")]
    public long? VBSermayeYedekleri { get; set; }

    [Column("V_B_1_Hisse_Senedi_Ihrac_Primleri")]
    public long? VB1HisseSenediIhracPrimleri { get; set; }

    [Column("V_B_2_Hisse_Senedi_Iptal_Karlari")]
    public long? VB2HisseSenediIptalKarlari { get; set; }

    [Column("V_B_3_Maddi_Duran_Varlik_Yeniden_Degerleme_Artislari")]
    public long? VB3MaddiDuranVarlikYenidenDegerlemeArtislari { get; set; }

    [Column("V_B_4_Istirakler_Yeniden_Degerleme_Artislari")]
    public long? VB4IstiraklerYenidenDegerlemeArtislari { get; set; }

    [Column("V_B_5_Diger_Sermaye_Yedekleri")]
    public long? VB5DigerSermayeYedekleri { get; set; }

    [Column("V_B_6_Kayda_Alinan_Emtia_Ozel_Karsilik_Hesabi")]
    public long? VB6KaydaAlinanEmtiaOzelKarsilikHesabi { get; set; }

    [Column("V_B_7_Demirbas_Makine_ve_Techizat_Ozel_Karsilik_Hesabi")]
    public long? VB7DemirbasMakineVeTechizatOzelKarsilikHesabi { get; set; }

    [Column("V_C_Kar_Yedekleri")]
    public long? VCKarYedekleri { get; set; }

    [Column("V_C_1_Yasal_Yedekler")]
    public long? VC1YasalYedekler { get; set; }

    [Column("V_C_2_Statu_Yedekleri")]
    public long? VC2StatuYedekleri { get; set; }

    [Column("V_C_3_Olaganustu_Yedekler")]
    public long? VC3OlaganustuYedekler { get; set; }

    [Column("V_C_4_Diger_Kar_Yedekleri")]
    public long? VC4DigerKarYedekleri { get; set; }

    [Column("V_C_5_Ozel_Fonlar")]
    public long? VC5OzelFonlar { get; set; }

    [Column("V_D_Gecmis_Yil_Karlari")]
    public long? VDGecmisYilKarlari { get; set; }

    [Column("V_D_1_Gecmis_Yil_Karlari")]
    public long? VD1GecmisYilKarlari { get; set; }

    [Column("V_E_Gecmis_Yillar_Zararlari_(-)")]
    public long? VEGecmisYillarZararlari { get; set; }

    [Column("V_E_1_Gecmis_Yillar_Zararlari_(-)")]
    public long? VE1GecmisYillarZararlari { get; set; }

    [Column("V_F_Donem_Net_Kari_(Zarari)")]
    public long? VFDonemNetKariZarari { get; set; }

    [Column("V_F_1_Donem_Net_Kari")]
    public long? VF1DonemNetKari { get; set; }

    [Column("V_F_2_Donem_Net_Zarari_(-)")]
    public long? VF2DonemNetZarari { get; set; }
}
