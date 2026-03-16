using FinanceCheckUp.Application.Behaviors;
using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Features.BaseApp.Authentication.Query.AuthenticationLogin;
using FinanceCheckUp.Application.Managers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Mapper;
using FinanceCheckUp.Application.Models.SignOperation;
using FinanceCheckUp.Application.Repository;
using FinanceCheckUp.Application.Services;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Client.ConnectApi;
using FinanceCheckUp.Client.QnbClient;
using FinanceCheckUp.Client.Wsdl;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using FinanceCheckUp.Infrastructure.Repository;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FinanceCheckUp.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        return services
            .AddScoped<IAuthenticationHelperService, AuthenticationHelperService>()
            .AddScoped<IFileOperationService, FileOperationService>()
            .AddScoped<IGenericResponse, GenericResponse>();
    }

    public static IServiceCollection AddManagerDependencies(this IServiceCollection services) => services
            .AddScoped<IGenericDapperRepository, GenericDapperRepositoryBase>()
            .AddScoped<ISqlOperationalHelper, SqlOperationalHelper>()
            .AddScoped<IMizanSqlOperationManager, MizanSqlOperationManager>()
            .AddScoped<IAppLogsManager, AppLogsManager>()
            .AddScoped<IBeyannameChkGeciciManager, BeyannameChkGeciciManager>()
            .AddScoped<IBeyannameChkManager, BeyannameChkManager>()
            .AddScoped<IBultenManager, BultenManager>()
            .AddScoped<ICompanyManager, CompanyManager>()
            .AddScoped<ICompanyEntegratorManager, CompanyEntegratorManager>()
            .AddScoped<IDashAktarmaSqlOperationManager, DashAktarmaSqlOperationManager>()
            .AddScoped<IDashBilancoBeyanManager, DashBilancoBeyanManager>()
            .AddScoped<IDashBilancoMizanDefterManager, DashBilancoMizanDefterManager>()
            .AddScoped<IDashBilancoMizanManager, DashBilancoMizanManager>()
            .AddScoped<IDashBilancoSetBeyanManager, DashBilancoSetBeyanManager>()
            .AddScoped<IDashBilancoSetMizanManager, DashBilancoSetMizanManager>()
            .AddScoped<IDashBilancoSetQnbASqlOperationManager, DashBilancoSetQnbASqlOperationManager>()
            .AddScoped<IDashBilancoSetQnbBSqlOperationManager, DashBilancoSetQnbBSqlOperationManager>()
            .AddScoped<IDashBilancoSetQnbCSqlOperationManager, DashBilancoSetQnbCSqlOperationManager>()
            .AddScoped<IDashBilancoSetQnbDSqlOperationManager, DashBilancoSetQnbDSqlOperationManager>()
            .AddScoped<IDashBilancoSetQnbGelirAManager, DashBilancoSetQnbGelirAManager>()
            .AddScoped<IDashBilancoSetQnbGelirBManager, DashBilancoSetQnbGelirBManager>()
            .AddScoped<IDashBilancoSetQnbGelirCManager, DashBilancoSetQnbGelirCManager>()
            .AddScoped<IDashBilancoSetQnbGelirDManager, DashBilancoSetQnbGelirDManager>()
            .AddScoped<IDashBilancoSetQnbGelirEManager, DashBilancoSetQnbGelirEManager>()
            .AddScoped<IDashBilancoSetQnbGelirFManager, DashBilancoSetQnbGelirFManager>()
            .AddScoped<IDashBilancoSetQnbGelirGManager, DashBilancoSetQnbGelirGManager>()
            .AddScoped<IDashBilancoSetQnbGelirHManager, DashBilancoSetQnbGelirHManager>()
            .AddScoped<IDashBilancoSetQnbGelirIManager, DashBilancoSetQnbGelirIManager>()
            .AddScoped<IDashBilancoSetQnbGelirManager, DashBilancoSetQnbGelirManager>()
            .AddScoped<IDashBilancoSetQnbSqlOperationManager, DashBilancoSetQnbSqlOperationManager>()
            .AddScoped<IDashBilancoViewCheckQnbManager, DashBilancoViewCheckQnbManager>()
            .AddScoped<IDashBilancoViewMainQnbGelirManager, DashBilancoViewMainQnbGelirManager>()
            .AddScoped<IDashBilancoViewMainQnbManager, DashBilancoViewMainQnbManager>()
            .AddScoped<IDashBilancoViewMizanCheckManager, DashBilancoViewMizanCheckManager>()
            .AddScoped<IDashBoardManager, DashBoardManager>()
            .AddScoped<IDashBoardRasyoManager, DashBoardRasyoManager>()
            .AddScoped<IDashFinansmanGelirKambiyoManager, DashFinansmanGelirKambiyoManager>()
            .AddScoped<IDashFinansmanGiderManager, DashFinansmanGiderManager>()
            .AddScoped<IDashGelirTablosuBeyanManager, DashGelirTablosuBeyanManager>()
            .AddScoped<IDashGelirTablosuManager, DashGelirTablosuManager>()
            .AddScoped<IDashGelirTablosuMizanDefterManager, DashGelirTablosuMizanDefterManager>()
            .AddScoped<IDashGelirTablosuMizanManager, DashGelirTablosuMizanManager>()
            .AddScoped<IDashGelirTablosuSetManager, DashGelirTablosuSetManager>()
            .AddScoped<IDashGelirTablosuViewTManager, DashGelirTablosuViewTManager>()
            .AddScoped<IDashLikiditeCheckMizanManager, DashLikiditeCheckMizanManager>()
            .AddScoped<IDashLikiditeMizanManager, DashLikiditeMizanManager>()
            .AddScoped<IDashLikiditeRiskTrendManager, DashLikiditeRiskTrendManager>()
            .AddScoped<IDashLikiditeRiskTrendMizanManager, DashLikiditeRiskTrendMizanManager>()
            .AddScoped<IDashLikiditeViewMainMizanManager, DashLikiditeViewMainMizanManager>()
            .AddScoped<IDashOzetMaliManager, DashOzetMaliManager>()
            .AddScoped<IDashOzetMaliMizanManager, DashOzetMaliMizanManager>()
            .AddScoped<IDashRasyoManager, DashRasyoManager>()
            .AddScoped<IDashRasyoMizanManager, DashRasyoMizanManager>()
            .AddScoped<IDashWCapitalCheckMizanManager, DashWCapitalCheckMizanManager>()
            .AddScoped<IDashWCapitalMizanManager, DashWCapitalMizanManager>()
            .AddScoped<IDashWCapitalViewMainMizanManager, DashWCapitalViewMainMizanManager>()
            .AddScoped<IDataManager, DataManager>()
            .AddScoped<IDatazManager, DatazManager>()
            .AddScoped<IDistrictsManager, DistrictsManager>()
            .AddScoped<IEmailTemplatesManager, EmailTemplatesManager>()
            .AddScoped<IERRLOGManager, ERRLOGManager>()
            .AddScoped<IErrorCheckMainManager, ErrorCheckMainManager>()
            .AddScoped(typeof(IHhvnUsersManager), typeof(HhvnUsersManager))
            .AddScoped<IMainDashManager, MainDashManager>()
            .AddScoped<IMizanResultManager, MizanResultManager>()
            .AddScoped<INaceCodeManager, NaceCodeManager>()
            .AddScoped<IRasyoAnalizMainManager, RasyoAnalizMainManager>()
            .AddScoped<IRasyoAnalizMainMizanManager, RasyoAnalizMainMizanManager>()
            .AddScoped<IReportCheckZoneManager, ReportCheckZoneManager>()
            .AddScoped<IReportDashManager, ReportDashManager>()
            .AddScoped<IReportDashMizanManager, ReportDashMizanManager>()
            .AddScoped<IReportSetMainAktarmaSqlOperationManager, ReportSetMainAktarmaSqlOperationManager>()
            .AddScoped<IReportSetMainSqlOperationManager, ReportSetMainSqlOperationManager>()
            .AddScoped<IShedulerMainManager, ShedulerMainManager>()
            .AddScoped<IStockHistoryViewManager, StockHistoryViewManager>()
            .AddScoped<ISupportGroupManager, SupportGroupManager>()
            .AddScoped<ISupportGroupMemberManager, SupportGroupMemberManager>()
            .AddScoped<ITBLAAQnbSignLogManager, TBLAAQnbSignLogManager>()
            .AddScoped<ITBLMizanManager, TBLMizanManager>()
            .AddScoped<ITblxmJournalFileManager, TblxmJournalFileManager>()
            .AddScoped<ITBLXmlFileManager, TBLXmlFileManager>()
            .AddScoped<ITBLXmlFolderFileManager, TBLXmlFolderFileManager>()
            .AddScoped<ITBLXmlManager, TBLXmlManager>()
            .AddScoped<ITBLXMLSourceMainManager, TBLXMLSourceMainManager>()
            .AddScoped<IUploadMainManager, UploadMainManager>()
            .AddScoped<IUserManager, UserManager>()
            .AddScoped<IUserCompanyManager, UserCompanyManager>()
            .AddScoped<IUserLoginManager, UserLoginManager>()
            .AddScoped<IUserSignalManager, UserSignalManager>()
            .AddScoped<IUserTypeManager, UserTypeManager>()
            .AddScoped<IXmlCheckerManager, XmlCheckerManager>()
            .AddScoped<IDashLikiditeViewMainManager, DashLikiditeViewMainManager>()
            .AddScoped<IDashWCapitalViewMainManager, DashWCapitalViewMainManager>()
            .AddScoped<IDashWCapitalManager, DashWCapitalManager>()
            .AddScoped<IDashGelirTablosuViewMainManager, DashGelirTablosuViewMainManager>()
        .AddScoped<IReminderAccountManager, ReminderAccountManager>()
        .AddScoped<IReminderAccountGroupManager, ReminderAccountGroupManager>()
        .AddScoped<IReminderRuleManager, ReminderRuleManager>()
        .AddScoped<IReminderRuleJobManager, ReminderRuleJobManager>()
        .AddScoped<IReminderRuleJobHistoryManager, ReminderRuleJobHistoryManager>()
        .AddScoped<ICitiesManager, CitiesManager>()
        .AddScoped<ICompanyQnbReportManager, CompanyQnbReportManager>()
        .AddScoped<ICompanyReportManager, CompanyReportManager>()
        .AddScoped<IReportMizanCheckManager, ReportMizanCheckManager>()
        .AddScoped<IDashLikiditeManager, DashLikiditeManager>()
        .AddScoped<IComReportManager,ComReportManager>();

    public static IServiceCollection AddConfigurationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        return services
                .Configure<TokenOptions>(configuration.GetSection(nameof(TokenOptions)))
                .Configure<SmtpSettings>(configuration.GetSection(nameof(SmtpSettings)))
                .Configure<SoapHelperSettings>(configuration.GetSection(nameof(SoapHelperSettings)))
                .Configure<AuthenticationSettings>(configuration.GetSection(nameof(AuthenticationSettings)))
                .Configure<QNBpay>(configuration.GetSection(nameof(QNBpay)));


    }

    public static IServiceCollection AddClientDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        return services // bu client applerde ayrılabilir.  Her api de olmak zorunda değil
            .AddHttpClient()
            .AddFinansmanEntegrasyonServiceOperationClient(configuration)
            .AddConnectApiServiceOperationClient(configuration)
            .AddQnbClients(configuration);
    }

    public static IServiceCollection RegistrationMediatR(this IServiceCollection services)
    {
         services.AddMediatR(typeof(AuthenticationLoginQuery).GetTypeInfo().Assembly);
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserIdBehavior<,>));

         return services;
    }

    public static IServiceCollection RegistrationFluentValidation(this IServiceCollection services)
    {
        return services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                       .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    public static IServiceCollection RegistrationAutoMapper(this IServiceCollection services)
    {
        return services.AddAutoMapper(cfg=> 
        {
            cfg.AddProfile<BultenMapperProfile>();
            cfg.AddProfile<UserMapperProfile>();
        },Assembly.GetExecutingAssembly());
    }


    public static IServiceCollection RegistrationGenericRepository(this IServiceCollection services)
    {
        //return services.AddRepositoryRegister(Assembly.GetExecutingAssembly());
        return services
            .AddScoped(typeof(IGenericRepository<,>), typeof(GenericBaseRepository<,>))
            .AddScoped(typeof(IQueryableRepository<,>), typeof(BaseQueryableRepository<,>))
            .AddScoped(typeof(IExecutableRepository<,>), typeof(BaseExecutableRepository<,>))
            //.AddScoped(typeof(IQueryableRepositoryExtra<,>), typeof(BaseQueryableRepository<,>))
            .AddScoped<IAppointmentRepository, AppointmentRepository>()
            .AddScoped<IBultenRepository, BultenRepository>()
            .AddScoped<ICompanyRepository, CompanyRepository>()
            .AddScoped<IDatazRepository, DatazRepository>()
            .AddScoped<IReminderRuleJobHistoryRepository, ReminderRuleJobHistoryRepository>()
            .AddScoped<IReminderRuleJobRepository, ReminderRuleJobRepository>()
            .AddScoped<IReminderRuleRepository, ReminderRuleRepository>()
            .AddScoped<ITblerrzoneRepository, TblerrzoneRepository>()
            .AddScoped<ITblwzoneRepository, TblwzoneRepository>()
            .AddScoped<IUserCompanyRepository, UserCompanyRepository>()
            .AddScoped<IUserRepository, UserRepository>();
    }

    public static IServiceCollection AddRepositoryRegister(this IServiceCollection services, Assembly executingAssembly)
    {

        foreach (Type item in executingAssembly.GetTypes().Where(delegate (Type t)
        {
            Type? baseType = t.BaseType;
            return baseType is not null && baseType.IsGenericType && t.BaseType != null && t.BaseType.GetGenericTypeDefinition().Name.Contains("Repository");
        }).ToList())
        {
            Type[] interfaces = item.GetInterfaces();
            foreach (Type serviceType in interfaces)
            {
                services.AddScoped(serviceType, item);
            }
        }

        return services;
    }

    public static IServiceCollection RegistrationDatabases(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FinanceCheckUpDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
        return services;
    }




    public static IServiceCollection AddHealthCheckDependencies(this IServiceCollection services)
    {
        services.AddHealthChecks();
        return services;
    }
}
