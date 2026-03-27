using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Domain.Entities.BgServer;
using Microsoft.EntityFrameworkCore;

namespace FinanceCheckUp.Application.Contexts.Concretes.Databases;

public class FinanceCheckUpDbContext(DbContextOptions<FinanceCheckUpDbContext> options) : DbContext(options)
{
    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Bulten> Bultens { get; set; }

    public virtual DbSet<Bwarn> Bwarns { get; set; }

    public virtual DbSet<BwarnSil> BwarnSils { get; set; }

    public virtual DbSet<CAccounterror> CAccounterrors { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Code> Codes { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyCheck> CompanyChecks { get; set; }

    public virtual DbSet<CompanyCheckKon> CompanyCheckKons { get; set; }

    public virtual DbSet<CompanyEntegrator> CompanyEntegrators { get; set; }

    public virtual DbSet<CompanyQnbReport> CompanyQnbReports { get; set; }

    public virtual DbSet<CompanyXmlSource> CompanyXmlSources { get; set; }

    public virtual DbSet<DatumMain> DatumMains { get; set; }

    public virtual DbSet<DeletedCompany> DeletedCompanies { get; set; }

    public virtual DbSet<ErrorMain> ErrorMains { get; set; }

    public virtual DbSet<Errorview> Errorviews { get; set; }

    public virtual DbSet<Logger> Loggers { get; set; }

    public virtual DbSet<McodeDesign> McodeDesigns { get; set; }

    public virtual DbSet<McodeZen> McodeZens { get; set; }

    public virtual DbSet<McodeZenCat> McodeZenCats { get; set; }

    public virtual DbSet<McodeZenChk> McodeZenChks { get; set; }

    public virtual DbSet<McodeZenQnb> McodeZenQnbs { get; set; }

    public virtual DbSet<McodeZenQnbId> McodeZenQnbIds { get; set; }

    public virtual DbSet<Nacecode> Nacecodes { get; set; }

    public virtual DbSet<Nacecodemain> Nacecodemains { get; set; }

    public virtual DbSet<Nacecodemn> Nacecodemns { get; set; }

    public virtual DbSet<ReminderAccount> ReminderAccounts { get; set; }

    public virtual DbSet<ReminderAccountGroup> ReminderAccountGroups { get; set; }

    public virtual DbSet<ReminderRule> ReminderRules { get; set; }

    public virtual DbSet<ReminderRuleGroup> ReminderRuleGroups { get; set; }

    public virtual DbSet<ReminderRuleJob> ReminderRuleJobs { get; set; }

    public virtual DbSet<ReminderRuleJobHistory> ReminderRuleJobHistories { get; set; }

    public virtual DbSet<ReportDetail> ReportDetails { get; set; }

    public virtual DbSet<ReverseCatch> ReverseCatches { get; set; }

    public virtual DbSet<RuleGroup> RuleGroups { get; set; }

    public virtual DbSet<SpoErrorList> SpoErrorLists { get; set; }

    public virtual DbSet<SpoTbmlaktarma> SpoTbmlaktarmas { get; set; }

    public virtual DbSet<TblaaqnbSignLog> TblaaqnbSignLogs { get; set; }

    public virtual DbSet<Tblalacakdevirhiz> Tblalacakdevirhizs { get; set; }

    public virtual DbSet<Tblbankakrediaktifler> Tblbankakrediaktiflers { get; set; }

    public virtual DbSet<Tblbankakrediyabkaynak> Tblbankakrediyabkaynaks { get; set; }

    public virtual DbSet<Tblbdonenvarlikaktif> Tblbdonenvarlikaktifs { get; set; }

    public virtual DbSet<Tblbeyanname> Tblbeyannames { get; set; }

    public virtual DbSet<Tblbkvadealackaktif> Tblbkvadealackaktifs { get; set; }

    public virtual DbSet<Tblbkvadealackdonen> Tblbkvadealackdonens { get; set; }

    public virtual DbSet<Tblbkvadekynkpasif> Tblbkvadekynkpasifs { get; set; }

    public virtual DbSet<Tblbmddiduranokaynk> Tblbmddiduranokaynks { get; set; }

    public virtual DbSet<TblboaFile> TblboaFiles { get; set; }

    public virtual DbSet<TblboaRequest> TblboaRequests { get; set; }

    public virtual DbSet<Tblbokynkaktif> Tblbokynkaktifs { get; set; }

    public virtual DbSet<Tblbokynkybncikynk> Tblbokynkybncikynks { get; set; }

    public virtual DbSet<Tblbstokaktif> Tblbstokaktifs { get; set; }

    public virtual DbSet<Tblbstokdevirhiz> Tblbstokdevirhizs { get; set; }

    public virtual DbSet<Tblbuvadeyabkynkpsf> Tblbuvadeyabkynkpsfs { get; set; }

    public virtual DbSet<TbldataErrored> TbldataErroreds { get; set; }

    public virtual DbSet<Tbldballrevenuedb> Tbldballrevenuedbs { get; set; }

    public virtual DbSet<Tbldbmoncom> Tbldbmoncoms { get; set; }

    public virtual DbSet<Tbldbsektoralliv> Tbldbsektorallivs { get; set; }

    public virtual DbSet<Tblduranvarlikozkynk> Tblduranvarlikozkynks { get; set; }

    public virtual DbSet<TblerrColor> TblerrColors { get; set; }

    public virtual DbSet<Tblerrzone> Tblerrzones { get; set; }

    public virtual DbSet<TblerrzoneInside> TblerrzoneInsides { get; set; }

    public virtual DbSet<TblerrzoneInsideWord> TblerrzoneInsideWords { get; set; }

    public virtual DbSet<TblerrzoneInsideWordOut> TblerrzoneInsideWordOuts { get; set; }

    public virtual DbSet<TblerrzoneInsideXml> TblerrzoneInsideXmls { get; set; }

    public virtual DbSet<TblerrzoneWord> TblerrzoneWords { get; set; }

    public virtual DbSet<TblerrzoneWordSub> TblerrzoneWordSubs { get; set; }

    public virtual DbSet<Tblf10maddidrnaktif> Tblf10maddidrnaktifs { get; set; }

    public virtual DbSet<Tblf11nakitoran> Tblf11nakitorans { get; set; }

    public virtual DbSet<Tblf12netkataktif> Tblf12netkataktifs { get; set; }

    public virtual DbSet<Tblf13netkarnetst> Tblf13netkarnetsts { get; set; }

    public virtual DbSet<Tblf14netkarozkynk> Tblf14netkarozkynks { get; set; }

    public virtual DbSet<Tblf15satlnmalnetst> Tblf15satlnmalnetsts { get; set; }

    public virtual DbSet<Tblf16stokdonen> Tblf16stokdonens { get; set; }

    public virtual DbSet<Tblf17vergioncsiozkynk> Tblf17vergioncsiozkynks { get; set; }

    public virtual DbSet<Tblf18faizgidrnetsati> Tblf18faizgidrnetsatis { get; set; }

    public virtual DbSet<Tblf19faizoncesikarzrr> Tblf19faizoncesikarzrrs { get; set; }

    public virtual DbSet<Tblf1brutkarnet> Tblf1brutkarnets { get; set; }

    public virtual DbSet<Tblf2cari> Tblf2caris { get; set; }

    public virtual DbSet<Tblf3durabvarybnckynk> Tblf3durabvarybnckynks { get; set; }

    public virtual DbSet<Tblf4ffalytkrnetst> Tblf4ffalytkrnetsts { get; set; }

    public virtual DbSet<Tblf5falytgdrnetst> Tblf5falytgdrnetsts { get; set; }

    public virtual DbSet<Tblf6faizoncesitoran> Tblf6faizoncesitorans { get; set; }

    public virtual DbSet<Tblf7kvadekrdkyabk> Tblf7kvadekrdkyabks { get; set; }

    public virtual DbSet<Tblf8likiditeoran> Tblf8likiditeorans { get; set; }

    public virtual DbSet<Tblf9maddidrnuvade> Tblf9maddidrnuvades { get; set; }

    public virtual DbSet<TblkarZararByMonth> TblkarZararByMonths { get; set; }

    public virtual DbSet<TblkarZararByMonthMizan> TblkarZararByMonthMizans { get; set; }

    public virtual DbSet<Tbllikidite> Tbllikidites { get; set; }

    public virtual DbSet<TbllikiditeMzn> TbllikiditeMzns { get; set; }

    public virtual DbSet<TblmainGrowHeaderMain> TblmainGrowHeaderMains { get; set; }

    public virtual DbSet<Tblmdonukaccnt> Tblmdonukaccnts { get; set; }

    public virtual DbSet<Tblmdonukaccntchk> Tblmdonukaccntchks { get; set; }

    public virtual DbSet<Tblmdonukaccntchkyear> Tblmdonukaccntchkyears { get; set; }

    public virtual DbSet<Tblmizan> Tblmizans { get; set; }

    public virtual DbSet<TblmizanErrzone> TblmizanErrzones { get; set; }

    public virtual DbSet<TblmizanErrzoneResult> TblmizanErrzoneResults { get; set; }

    public virtual DbSet<TblmizanErrzoneResultYson> TblmizanErrzoneResultYsons { get; set; }

    public virtual DbSet<Tblmnktaki> Tblmnktakis { get; set; }

    public virtual DbSet<Tblmnkzone> Tblmnkzones { get; set; }

    public virtual DbSet<TblmnkzoneDetail> TblmnkzoneDetails { get; set; }

    public virtual DbSet<TblmqnbReport> TblmqnbReports { get; set; }

    public virtual DbSet<TblmqnbReportRatio> TblmqnbReportRatios { get; set; }

    public virtual DbSet<TblmqnbReportRatioChart> TblmqnbReportRatioCharts { get; set; }

    public virtual DbSet<TblmqnbReportRatioChartShrt> TblmqnbReportRatioChartShrts { get; set; }

    public virtual DbSet<TblmqnbReportRatioPoint> TblmqnbReportRatioPoints { get; set; }

    public virtual DbSet<TblmqnbReportRatioView> TblmqnbReportRatioViews { get; set; }

    public virtual DbSet<TblmqnbReportShrt> TblmqnbReportShrts { get; set; }

    public virtual DbSet<Tblmrevenue> Tblmrevenues { get; set; }

    public virtual DbSet<TblmrevenueMzn> TblmrevenueMzns { get; set; }

    public virtual DbSet<TblmrevenueRasT> TblmrevenueRasTs { get; set; }

    public virtual DbSet<TblmrevenueRasTkon> TblmrevenueRasTkons { get; set; }

    public virtual DbSet<TblmsampleBlnco> TblmsampleBlncos { get; set; }

    public virtual DbSet<TblmsampleBlncoMzn> TblmsampleBlncoMzns { get; set; }

    public virtual DbSet<TblmsampleBlncoRasT> TblmsampleBlncoRasTs { get; set; }

    public virtual DbSet<TblmsampleBlncoRasTkon> TblmsampleBlncoRasTkons { get; set; }

    public virtual DbSet<TblmsampleBlncoShrt> TblmsampleBlncoShrts { get; set; }

    public virtual DbSet<TblmsampleBlncoShrtCustom> TblmsampleBlncoShrtCustoms { get; set; }

    public virtual DbSet<TblmsampleBlncoShrtCustomPr> TblmsampleBlncoShrtCustomPrs { get; set; }

    public virtual DbSet<TblmstempHder> TblmstempHders { get; set; }

    public virtual DbSet<TbloneCheck> TbloneChecks { get; set; }

    public virtual DbSet<TblspMainGrow> TblspMainGrows { get; set; }

    public virtual DbSet<TblspMainGrowHeader> TblspMainGrowHeaders { get; set; }

    public virtual DbSet<TblwcapArGeGider> TblwcapArGeGiders { get; set; }

    public virtual DbSet<TblwcapArGeGiderMizan> TblwcapArGeGiderMizans { get; set; }

    public virtual DbSet<TblwcapBrutKarZarar> TblwcapBrutKarZarars { get; set; }

    public virtual DbSet<TblwcapBrutKarZararMizan> TblwcapBrutKarZararMizans { get; set; }

    public virtual DbSet<TblwcapDonemKarZarar> TblwcapDonemKarZarars { get; set; }

    public virtual DbSet<TblwcapDonemKarZararMizan> TblwcapDonemKarZararMizans { get; set; }

    public virtual DbSet<TblwcapDonemKarZararNet> TblwcapDonemKarZararNets { get; set; }

    public virtual DbSet<TblwcapDonemKarZararNetMizan> TblwcapDonemKarZararNetMizans { get; set; }

    public virtual DbSet<TblwcapEsasMaliyetKarZarar> TblwcapEsasMaliyetKarZarars { get; set; }

    public virtual DbSet<TblwcapEsasMaliyetKarZararMizan> TblwcapEsasMaliyetKarZararMizans { get; set; }

    public virtual DbSet<TblwcapEsmm> TblwcapEsmms { get; set; }

    public virtual DbSet<TblwcapEsmmMizan> TblwcapEsmmMizans { get; set; }

    public virtual DbSet<TblwcapFaaliyetKarZarar> TblwcapFaaliyetKarZarars { get; set; }

    public virtual DbSet<TblwcapFaaliyetKarZararMizan> TblwcapFaaliyetKarZararMizans { get; set; }

    public virtual DbSet<TblwcapFinansmanGider> TblwcapFinansmanGiders { get; set; }

    public virtual DbSet<TblwcapFinansmanGiderMizan> TblwcapFinansmanGiderMizans { get; set; }

    public virtual DbSet<TblwcapGenelYonGider> TblwcapGenelYonGiders { get; set; }

    public virtual DbSet<TblwcapGenelYonGiderMizan> TblwcapGenelYonGiderMizans { get; set; }

    public virtual DbSet<TblwcapNetSati> TblwcapNetSatis { get; set; }

    public virtual DbSet<TblwcapNetSatisMizan> TblwcapNetSatisMizans { get; set; }

    public virtual DbSet<TblwcapNetSatisTest> TblwcapNetSatisTests { get; set; }

    public virtual DbSet<TblwcapOlaganKarZarar> TblwcapOlaganKarZarars { get; set; }

    public virtual DbSet<TblwcapOlaganKarZararMizan> TblwcapOlaganKarZararMizans { get; set; }

    public virtual DbSet<TblwcapPazarlamaGider> TblwcapPazarlamaGiders { get; set; }

    public virtual DbSet<TblwcapPazarlamaGiderMizan> TblwcapPazarlamaGiderMizans { get; set; }

    public virtual DbSet<Tblwcapital> Tblwcapitals { get; set; }

    public virtual DbSet<TblwcapitalMzn> TblwcapitalMzns { get; set; }

    public virtual DbSet<Tblwzone> Tblwzones { get; set; }

    public virtual DbSet<TblwzoneYd> TblwzoneYds { get; set; }

    public virtual DbSet<TblxmJournalFile> TblxmJournalFiles { get; set; }

    public virtual DbSet<Tblxml> Tblxmls { get; set; }

    public virtual DbSet<TblxmlDel> TblxmlDels { get; set; }

    public virtual DbSet<TblxmlFile> TblxmlFiles { get; set; }

    public virtual DbSet<TblxmlFolderFile> TblxmlFolderFiles { get; set; }

    public virtual DbSet<Tblxmlpurification> Tblxmlpurifications { get; set; }

    public virtual DbSet<TblxmlscheckpdfMizan> TblxmlscheckpdfMizans { get; set; }

    public virtual DbSet<Tblxmlsource> Tblxmlsources { get; set; }

    public virtual DbSet<TblxmlsourceByn> TblxmlsourceByns { get; set; }

    public virtual DbSet<TblxmlsourceBynChk> TblxmlsourceBynChks { get; set; }

    public virtual DbSet<TblxmlsourceChk> TblxmlsourceChks { get; set; }

    public virtual DbSet<TblxmlsourceMain> TblxmlsourceMains { get; set; }

    public virtual DbSet<TblxmlsourceOne> TblxmlsourceOnes { get; set; }

    public virtual DbSet<TblxmlsourceOneBck> TblxmlsourceOneBcks { get; set; }

    public virtual DbSet<TblxmlsourceOneKon> TblxmlsourceOneKons { get; set; }

    public virtual DbSet<TblxmlsourceOneM> TblxmlsourceOneMs { get; set; }

    public virtual DbSet<TblxmlsourceOnePr> TblxmlsourceOnePrs { get; set; }

    public virtual DbSet<TblxmlsourceOnePrHst> TblxmlsourceOnePrHsts { get; set; }

    public virtual DbSet<TblxmlsourceOneT> TblxmlsourceOneTs { get; set; }

    public virtual DbSet<TblxmlsourceSub> TblxmlsourceSubs { get; set; }

    public virtual DbSet<TblzoneCheck> TblzoneChecks { get; set; }

    public virtual DbSet<TblzoneCheckMain> TblzoneCheckMains { get; set; }

    public virtual DbSet<TblzoneCheckSub> TblzoneCheckSubs { get; set; }

    public virtual DbSet<TblzoneM> TblzoneMs { get; set; }

    public virtual DbSet<Tbmlrepor01> Tbmlrepor01s { get; set; }

    public virtual DbSet<Tbmlrepor01mzn> Tbmlrepor01mzns { get; set; }

    public virtual DbSet<Tbmlrepor01z> Tbmlrepor01zs { get; set; }

    public virtual DbSet<Tbmlrepor01zmzn> Tbmlrepor01zmzns { get; set; }

    public virtual DbSet<Tbmlrepor01zt> Tbmlrepor01zts { get; set; }

    public virtual DbSet<Tbmlrepor01ztmzn> Tbmlrepor01ztmzns { get; set; }

    public virtual DbSet<Tbmlreport01> Tbmlreport01s { get; set; }

    public virtual DbSet<Tbmlreport01a> Tbmlreport01as { get; set; }

    public virtual DbSet<Tbmlreport01amzn> Tbmlreport01amzns { get; set; }

    public virtual DbSet<Tbmlreport01mzn> Tbmlreport01mzns { get; set; }

    public virtual DbSet<Tbmlreport03> Tbmlreport03s { get; set; }

    public virtual DbSet<Tbmlreport031a> Tbmlreport031as { get; set; }

    public virtual DbSet<Tbmlreport031amzn> Tbmlreport031amzns { get; set; }

    public virtual DbSet<Tbmlreport03mzn> Tbmlreport03mzns { get; set; }

    public virtual DbSet<Tbmlreport05> Tbmlreport05s { get; set; }

    public virtual DbSet<Tbmlreport051a> Tbmlreport051as { get; set; }

    public virtual DbSet<Tbmlreport051amzn> Tbmlreport051amzns { get; set; }

    public virtual DbSet<Tbmlreport051b> Tbmlreport051bs { get; set; }

    public virtual DbSet<Tbmlreport051bmzn> Tbmlreport051bmzns { get; set; }

    public virtual DbSet<Tbmlreport051c> Tbmlreport051cs { get; set; }

    public virtual DbSet<Tbmlreport051cmzn> Tbmlreport051cmzns { get; set; }

    public virtual DbSet<Tbmlreport05mzn> Tbmlreport05mzns { get; set; }

    public virtual DbSet<Tbmlreport07> Tbmlreport07s { get; set; }

    public virtual DbSet<Tbmlreport07mzn> Tbmlreport07mzns { get; set; }

    public virtual DbSet<TtzdashBoardFavo> TtzdashBoardFavos { get; set; }

    public virtual DbSet<TtzdashBoardHataSayi> TtzdashBoardHataSayis { get; set; }

    public virtual DbSet<TtzdashBoardOran> TtzdashBoardOrans { get; set; }

    public virtual DbSet<TtzdashBoardOranMzn> TtzdashBoardOranMzns { get; set; }

    public virtual DbSet<TtzdashBoardOzSrmy> TtzdashBoardOzSrmies { get; set; }

    public virtual DbSet<TtzdashBoardOzetLikidite> TtzdashBoardOzetLikidites { get; set; }

    public virtual DbSet<TtzdashBoardOzetLikiditeMzn> TtzdashBoardOzetLikiditeMzns { get; set; }

    public virtual DbSet<TtzdashBoardOzetMali> TtzdashBoardOzetMalis { get; set; }

    public virtual DbSet<TtzdashBoardOzetMaliMzn> TtzdashBoardOzetMaliMzns { get; set; }

    public virtual DbSet<TtzdashBoardWcapital> TtzdashBoardWcapitals { get; set; }

    public virtual DbSet<TtzsermayeToplam> TtzsermayeToplams { get; set; }

    public virtual DbSet<TtzsermayeToplamIki> TtzsermayeToplamIkis { get; set; }

    public virtual DbSet<TtzsermayeToplamUc> TtzsermayeToplamUcs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCompany> UserCompanies { get; set; }

    public virtual DbSet<UserDeleted> UserDeleteds { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserSignal> UserSignals { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<XmlCheckGroup> XmlCheckGroups { get; set; }

    public virtual DbSet<XmlCheckGroupMain> XmlCheckGroupMains { get; set; }

    public virtual DbSet<XmlCheckGroupTest> XmlCheckGroupTests { get; set; }

    public virtual DbSet<XmlChkSource> XmlChkSources { get; set; }

    public virtual DbSet<XmlSourceTb> XmlSourceTbs { get; set; }

    //Jwt için ekstra 
    //public virtual DbSet<OperationClaim> OperationClaim { get; set; }
    //public virtual DbSet<UserOperationClaim> UserOperationClaim { get; set; }
    public virtual DbSet<HhvnUsers> HhvnUsers { get; set; }









    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlServer(
            "server=178.251.238.131;database=EDEFTERDB;user id=sa;password=QaWsEdRfTg321*;Connection Timeout=500; Pooling=true; Max Pool Size=200;TrustServerCertificate=True");
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Appointment>(entity =>
    //    {
    //        entity.Property(e => e.AllDay).HasDefaultValue(true);
    //    });

    //    modelBuilder.Entity<Bulten>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<Bwarn>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<BwarnSil>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<Code>(entity =>
    //    {
    //        entity.Property(e => e.Code1).IsFixedLength();
    //        entity.Property(e => e.DashCheck).HasDefaultValue((byte)1);
    //    });

    //    modelBuilder.Entity<Company>(entity =>
    //    {
    //        entity.ToTable("Company", tb => tb.HasTrigger("CompanyDeleted"));

    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<CompanyEntegrator>(entity =>
    //    {
    //        entity.Property(e => e.IsVisible).HasDefaultValue((byte)1);
    //    });

    //    modelBuilder.Entity<CompanyQnbReport>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<CompanyXmlSource>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<DatumMain>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CsvMain");

    //        entity.Property(e => e.Id).ValueGeneratedNever();
    //    });

    //    modelBuilder.Entity<DeletedCompany>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<Errorview>(entity =>
    //    {
    //        entity.ToView("ERRORVIEW");
    //    });

    //    modelBuilder.Entity<Logger>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<McodeDesign>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CodesZone");
    //    });

    //    modelBuilder.Entity<McodeZen>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CodesZoneMain");
    //    });

    //    modelBuilder.Entity<McodeZenChk>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CodesZoneMCodeZenChk");
    //    });

    //    modelBuilder.Entity<ReportDetail>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_ResportDetail");
    //    });

    //    modelBuilder.Entity<ReverseCatch>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<SpoErrorList>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<SpoTbmlaktarma>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<TblaaqnbSignLog>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<Tblbeyanname>(entity =>
    //    {
    //        entity.Property(e => e.FirstChar).IsFixedLength();
    //        entity.Property(e => e.Id).ValueGeneratedOnAdd();
    //    });

    //    modelBuilder.Entity<TblboaFile>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<TblboaRequest>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<Tblbuvadeyabkynkpsf>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_TBLBUVADEYABKYNK");
    //    });

    //    modelBuilder.Entity<TbldataErrored>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CsvDataErrored");
    //    });

    //    modelBuilder.Entity<Tbldballrevenuedb>(entity =>
    //    {
    //        entity.Property(e => e.Id).ValueGeneratedOnAdd();
    //    });

    //    modelBuilder.Entity<Tbldbsektoralliv>(entity =>
    //    {
    //        entity.Property(e => e.Id).ValueGeneratedOnAdd();
    //    });

    //    modelBuilder.Entity<TblerrColor>(entity =>
    //    {
    //        entity.Property(e => e.Id).ValueGeneratedOnAdd();
    //    });

    //    modelBuilder.Entity<Tblerrzone>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<Tblf18faizgidrnetsati>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("TTBLF18FAIZGIDRNETSATIS");
    //    });

    //    modelBuilder.Entity<Tblf19faizoncesikarzrr>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("TTBLF19FAIZONCESIKARZRR");
    //    });

    //    modelBuilder.Entity<TblkarZararByMonthMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021L);
    //    });

    //    modelBuilder.Entity<TblmainGrowHeaderMain>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<Tblmizan>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_TBLMizanCsvInfo");

    //        entity.Property(e => e.MainMonth).HasDefaultValue(12);
    //        entity.Property(e => e.UploadDate).HasDefaultValueSql("(getdate())");
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblmizanErrzone>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<TblmizanErrzoneResult>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<TblmizanErrzoneResultYson>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<Tblmnktaki>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<Tblmnkzone>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<TblmnkzoneDetail>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<TblmqnbReportRatio>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblmrevenueRasTkon>(entity =>
    //    {
    //        entity.Property(e => e.Id).ValueGeneratedOnAdd();
    //    });

    //    modelBuilder.Entity<TblmsampleBlncoMzn>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<TblmsampleBlncoRasTkon>(entity =>
    //    {
    //        entity.Property(e => e.Id).ValueGeneratedOnAdd();
    //    });

    //    modelBuilder.Entity<TblspMainGrow>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblspMainGrowHeader>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapArGeGider>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapArGeGiderMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapBrutKarZarar>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapBrutKarZararMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapDonemKarZarar>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapDonemKarZararMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapDonemKarZararNet>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapDonemKarZararNetMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapEsasMaliyetKarZarar>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapEsasMaliyetKarZararMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapEsmm>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapEsmmMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapFaaliyetKarZarar>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapFaaliyetKarZararMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapFinansmanGider>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapFinansmanGiderMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapGenelYonGider>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapGenelYonGiderMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapNetSati>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapNetSatisMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapNetSatisTest>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapOlaganKarZarar>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapOlaganKarZararMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapPazarlamaGider>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblwcapPazarlamaGiderMizan>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<Tblwzone>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_YEVMIYE1GRUP");
    //    });

    //    modelBuilder.Entity<TblwzoneYd>(entity =>
    //    {
    //        entity.Property(e => e.Id).ValueGeneratedOnAdd();
    //    });

    //    modelBuilder.Entity<TblxmJournalFile>(entity =>
    //    {
    //        entity.Property(e => e.IsNegatif).HasDefaultValue(true);
    //    });

    //    modelBuilder.Entity<Tblxml>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CsvInfo");

    //        entity.Property(e => e.UploadDate).HasDefaultValueSql("(getdate())");
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblxmlDel>(entity =>
    //    {
    //        entity.Property(e => e.UploadDate).HasDefaultValueSql("(getdate())");
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblxmlFile>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<TblxmlFolderFile>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //        entity.Property(e => e.IsLedger).HasDefaultValue(true);
    //    });

    //    modelBuilder.Entity<Tblxmlpurification>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<Tblxmlsource>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CsvData");

    //        entity.Property(e => e.IsClosed).HasDefaultValue((byte)0);
    //        entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<TblxmlsourceByn>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //        entity.Property(e => e.IsRevenue).HasDefaultValue((byte)0);
    //    });

    //    modelBuilder.Entity<TblxmlsourceBynChk>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //        entity.Property(e => e.IsRevenue).HasDefaultValue((byte)0);
    //    });

    //    modelBuilder.Entity<TblxmlsourceMain>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CsvDataz");
    //    });

    //    modelBuilder.Entity<TblxmlsourceOneBck>(entity =>
    //    {
    //        entity.Property(e => e.MainMonth).HasDefaultValue(12);
    //    });

    //    modelBuilder.Entity<TblxmlsourceOneKon>(entity =>
    //    {
    //        entity.Property(e => e.Id).ValueGeneratedOnAdd();
    //    });

    //    modelBuilder.Entity<TblxmlsourceSub>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CsvDatazLast");
    //    });

    //    modelBuilder.Entity<TblzoneCheck>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_TestMainC");

    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TblzoneCheckSub>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TtzdashBoardFavo>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TtzdashBoardHataSayi>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TtzdashBoardOran>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TtzdashBoardOranMzn>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TtzdashBoardOzetLikidite>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TtzdashBoardOzetMali>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TtzdashBoardWcapital>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TtzsermayeToplam>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TtzsermayeToplamIki>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<TtzsermayeToplamUc>(entity =>
    //    {
    //        entity.Property(e => e.Year).HasDefaultValue(2021);
    //    });

    //    modelBuilder.Entity<User>(entity =>
    //    {
    //        entity.ToTable("User", tb => tb.HasTrigger("DeletedUser"));

    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //        entity.Property(e => e.IsActive).HasDefaultValue(true);
    //        entity.Property(e => e.SelectedYear).HasDefaultValue(2021);
    //        entity.Property(e => e.UserTypeId).HasDefaultValue(1);
    //    });

    //    modelBuilder.Entity<UserDeleted>(entity =>
    //    {
    //        entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
    //        entity.Property(e => e.IsActive).HasDefaultValue(true);
    //        entity.Property(e => e.SelectedYear).HasDefaultValue(2021);
    //        entity.Property(e => e.UserTypeId).HasDefaultValue(1);
    //    });

    //    modelBuilder.Entity<UserSignal>(entity =>
    //    {
    //        entity.Property(e => e.ActionDate).HasDefaultValueSql("(getdate())");
    //    });

    //    modelBuilder.Entity<XmlCheckGroup>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CSVGRUPTA");
    //    });

    //    modelBuilder.Entity<XmlCheckGroupMain>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CSVGRUPTZ");
    //    });

    //    modelBuilder.Entity<XmlCheckGroupTest>(entity =>
    //    {
    //        entity.Property(e => e.Id).ValueGeneratedOnAdd();
    //    });

    //    modelBuilder.Entity<XmlChkSource>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_CSVGRUPT");
    //    });

    //}

}
