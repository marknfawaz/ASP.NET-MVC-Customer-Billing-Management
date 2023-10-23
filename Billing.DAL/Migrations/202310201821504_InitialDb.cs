namespace Billing.DAL.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;

    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var t1 = migrationBuilder.CreateTable(
                "dbo.AgentLedgerHeads",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    LedgerHead = c.Column<string>(maxLength: 255),
                    LedgerTypes = c.Column<int>(nullable: false),
                    Edit = c.Column<bool>(nullable: false),
                    Status = c.Column<bool>(nullable: false),
                })
                .PrimaryKey("AgentLedgerHeads_PK", t => t.Id);

            migrationBuilder.CreateIndex("AgentLedgerHeads_LedgerHead_IX", "dbo.AgentLedgerHeads", "LedgerHead", unique: true);

            migrationBuilder.CreateTable(
                "dbo.AgentLedgers",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    AgentLedgerHeadId = c.Column<int>(nullable: false),
                    AgentId = c.Column<int>(nullable: false),
                    GeneralLedgerId = c.Column<int>(),
                    BankAccountLedgerId = c.Column<int>(),
                    PaymentMethods = c.Column<int>(),
                    PaymentType = c.Column<int>(),
                    Amount = c.Column<double>(nullable: false),
                    Balance = c.Column<double>(nullable: false),
                    Remarks = c.Column<string>(),
                    SystemDate = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("AgentLedgers_PK", t => t.Id);

            migrationBuilder.CreateIndex("AgentLedgers_AgentLedgerHeadId_IX", "dbo.AgentLedgers", "AgentLedgerHeadId");
            migrationBuilder.CreateIndex("AgentLedgers_AgentId_IX", "dbo.AgentLedgers", "AgentId");
            migrationBuilder.CreateIndex("AgentLedgers_GeneralLedgerId_IX", "dbo.AgentLedgers", "GeneralLedgerId");
            migrationBuilder.CreateIndex("AgentLedgers_BankAccountLedgerId_IX", "dbo.AgentLedgers", "BankAccountLedgerId");
            migrationBuilder.CreateIndex("AgentLedgers_ApplicationUserId_IX", "dbo.AgentLedgers", "ApplicationUserId");

            migrationBuilder.CreateTable(
                "dbo.Agents",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    ProfileType = c.Column<int>(nullable: false),
                    Name = c.Column<string>(),
                    Address = c.Column<string>(),
                    Email = c.Column<string>(),
                    Postcode = c.Column<string>(),
                    Telephone = c.Column<string>(),
                    Mobile = c.Column<string>(),
                    FaxNo = c.Column<string>(),
                    Atol = c.Column<string>(),
                    CreditLimit = c.Column<double>(nullable: false),
                    Balance = c.Column<double>(nullable: false),
                    Remarks = c.Column<string>(),
                    JoiningDate = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("Agents_PK", t => t.Id);
            migrationBuilder.CreateIndex("Agents_ApplicationUserId_IX", "dbo.Agents", "ApplicationUserId");

            migrationBuilder.CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.Column<string>(nullable: false, maxLength: 128),
                    PersonName = c.Column<string>(nullable: false),
                    MobileNo = c.Column<string>(maxLength: 20),
                    NationalId = c.Column<string>(maxLength: 50),
                    MaritialStatus = c.Column<int>(nullable: false),
                    Gender = c.Column<int>(nullable: false),
                    UserRoles = c.Column<int>(nullable: false),
                    UserStatus = c.Column<int>(nullable: false),
                    Email = c.Column<string>(maxLength: 256),
                    EmailConfirmed = c.Column<bool>(nullable: false),
                    PasswordHash = c.Column<string>(),
                    SecurityStamp = c.Column<string>(),
                    PhoneNumber = c.Column<string>(),
                    PhoneNumberConfirmed = c.Column<bool>(nullable: false),
                    TwoFactorEnabled = c.Column<bool>(nullable: false),
                    LockoutEndDateUtc = c.Column<DateTime>(),
                    LockoutEnabled = c.Column<bool>(nullable: false),
                    AccessFailedCount = c.Column<int>(nullable: false),
                    UserName = c.Column<string>(nullable: false, maxLength: 256),
                })
                .PrimaryKey("AspNetUsers_PK", t => t.Id);
            migrationBuilder.CreateIndex("AspNetUsers_MobileNo_IX", "AspNetUsers", "MobileNo", unique: true);
            migrationBuilder.CreateIndex("AspNetUsers_NationalId_IX", "AspNetUsers", "NationalId", unique: true);
            migrationBuilder.CreateIndex("AspNetUsers_UserName_IX", "AspNetUsers", "UserName", unique: true);

            migrationBuilder.CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    UserId = c.Column<string>(nullable: false, maxLength: 128),
                    ClaimType = c.Column<string>(),
                    ClaimValue = c.Column<string>(),
                })
                .PrimaryKey("AspNetUserClaims_PK", t => t.Id);
            migrationBuilder.CreateIndex("AspNetUserClaims_UserId_IX", "dbo.AspNetUserClaims", "UserId");

            migrationBuilder.CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.Column<string>(nullable: false, maxLength: 128),
                    ProviderKey = c.Column<string>(nullable: false, maxLength: 128),
                    UserId = c.Column<string>(nullable: false, maxLength: 128),
                })
                .PrimaryKey("AspNetUserLogins_PK", t => new { t.LoginProvider, t.ProviderKey, t.UserId });

            migrationBuilder.CreateIndex("AspNetUserLogins_UserId_IX", "dbo.AspNetUserLogins", "UserId");

            migrationBuilder.CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.Column<string>(nullable: false, maxLength: 128),
                    RoleId = c.Column<string>(nullable: false, maxLength: 128),
                })
                .PrimaryKey("AspNetUserRoles_PK", t => new { t.UserId, t.RoleId });
            migrationBuilder.CreateIndex("AspNetUserRoles_UserId_IX", "dbo.AspNetUserRoles", "UserId");
            migrationBuilder.CreateIndex("AspNetUserRoles_RoleId_IX", "dbo.AspNetUserRoles", "RoleId");

            migrationBuilder.CreateTable(
                "dbo.BankAccountLedgers",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountId = c.Column<int>(nullable: false),
                    BankAccountLedgerHeadId = c.Column<int>(nullable: false),
                    LedgerTypes = c.Column<int>(nullable: false),
                    PaymentMethods = c.Column<int>(nullable: false),
                    GeneralLedgerId = c.Column<int>(),
                    RelationId = c.Column<int>(),
                    Notes = c.Column<string>(),
                    Amount = c.Column<double>(nullable: false),
                    Balance = c.Column<double>(nullable: false),
                    SysDateTime = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("BankAccountLedgers_PK", t => t.Id);
            migrationBuilder.CreateIndex("BankAccountLedgers_BankAccountId_IX", "dbo.BankAccountLedgers", "BankAccountId");
            migrationBuilder.CreateIndex("BankAccountLedgers_BankAccountLedgerHeadId_IX", "dbo.BankAccountLedgers", "BankAccountLedgerHeadId");
            migrationBuilder.CreateIndex("BankAccountLedgers_GeneralLedgerId_IX", "dbo.BankAccountLedgers", "GeneralLedgerId");
            migrationBuilder.CreateIndex("BankAccountLedgers_ApplicationUserId_IX", "dbo.BankAccountLedgers", "ApplicationUserId");

            migrationBuilder.CreateTable(
                "dbo.BankAccountLedgerHeads",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    LedgerHead = c.Column<string>(maxLength: 100),
                    LedgerTypes = c.Column<int>(nullable: false),
                    Editable = c.Column<bool>(nullable: false),
                    Status = c.Column<bool>(nullable: false),
                    GeneralLedgerHeadId = c.Column<int>(),
                })
                .PrimaryKey("BankAccountLedgerHeads_PK", t => t.Id);

            migrationBuilder.CreateIndex("IX_FirstAndSecond", "dbo.BankAccountLedgerHeads", "LedgerHead", unique: true);
            migrationBuilder.CreateIndex("BankAccountLedgerHeads_GeneralLedgerHeadId_IX", "dbo.BankAccountLedgerHeads", "GeneralLedgerHeadId");

            migrationBuilder.CreateTable(
                "dbo.GeneralLedgerHeads",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    GeneralLedgerHeadName = c.Column<string>(),
                    GeneralLedgerType = c.Column<int>(nullable: false),
                    Editable = c.Column<bool>(nullable: false),
                    Status = c.Column<bool>(nullable: false),
                })
                .PrimaryKey("GeneralLedgerHeads_PK", t => t.Id);

            migrationBuilder.CreateTable(
                "dbo.BankAccounts",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    BankNames = c.Column<int>(nullable: false),
                    AccountNo = c.Column<string>(),
                    AccountNames = c.Column<string>(),
                    Balance = c.Column<double>(nullable: false),
                    AddedOn = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("BankAccounts_PK", t => t.Id);
            migrationBuilder.CreateIndex("BankAccounts_ApplicationUserId_IX", "dbo.BankAccounts", "ApplicationUserId");
            migrationBuilder.CreateIndex("ApplicationUserId_IX", "dbo.", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.GeneralLedgers",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    StatementTypes = c.Column<int>(nullable: false),
                    GeneralLedgerHeadId = c.Column<int>(nullable: false),
                    PaymentMethods = c.Column<int>(nullable: false),
                    GeneralLedgerType = c.Column<int>(nullable: false),
                    Amount = c.Column<double>(nullable: false),
                    Notes = c.Column<string>(),
                    SysDateTime = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("GeneralLedgers_PK", t => t.Id);
            migrationBuilder.CreateIndex("GeneralLedgers_GeneralLedgerHeadId_IX", "dbo.GeneralLedgers", "GeneralLedgerHeadId");
            migrationBuilder.CreateIndex("GeneralLedgers_ApplicationUserId_IX", "dbo.GeneralLedgers", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.Airlines",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = c.Column<string>(maxLength: 150),
                    Code = c.Column<string>(maxLength: 20),
                })
                .PrimaryKey("Airlines_PK", t => t.Id);
            migrationBuilder.CreateIndex("Airlines_Name_IX", "dbo.Airlines", "Name", unique: true);
            migrationBuilder.CreateIndex("Airlines_Code_IX", "dbo.Airlines", "Code", unique: true);

            migrationBuilder.CreateTable(
                "dbo.AirportCodes",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = c.Column<string>(),
                    Country = c.Column<string>(),
                    Code = c.Column<string>(),
                })
                .PrimaryKey("AirportCodes_PK", t => t.Id);

            migrationBuilder.CreateTable(
                "dbo.CashInHands",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Balance = c.Column<double>(nullable: false),
                })
                .PrimaryKey("CashInHands_PK", t => t.Id);

            migrationBuilder.CreateTable(
                "dbo.CompanyInfoes",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = c.Column<string>(),
                    Address = c.Column<string>(),
                    Telephone = c.Column<string>(),
                    FaxNo = c.Column<string>(),
                    Email = c.Column<string>(),
                    WebAddress = c.Column<string>(),
                    Atol = c.Column<double>(nullable: false),
                    CustomerSafi = c.Column<double>(nullable: false),
                    CreditCardCharge = c.Column<double>(nullable: false),
                    DebitCardCharge = c.Column<double>(nullable: false),
                    Apc = c.Column<double>(nullable: false),
                    AgentSafi = c.Column<double>(nullable: false),
                })
                .PrimaryKey("CompanyInfoes_PK", t => t.Id);

            migrationBuilder.CreateTable(
                "dbo.InvoiceLogs",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = c.Column<int>(nullable: false),
                    Remarks = c.Column<string>(),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                    SysDateTime = c.Column<DateTime>(nullable: false),
                })
                .PrimaryKey("InvoiceLogs_PK", t => t.Id);
            migrationBuilder.CreateIndex("InvoiceLogs_InvoiceId_IX", "dbo.InvoiceLogs", "InvoiceId");
            migrationBuilder.CreateIndex("InvoiceLogs_ApplicationUserId_IX", "dbo.", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.Invoices",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceType = c.Column<int>(nullable: false),
                    AgentId = c.Column<int>(nullable: false),
                    GdsBookingDate = c.Column<string>(),
                    AirlinesId = c.Column<int>(nullable: false),
                    SysCreateDate = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                    VendorId = c.Column<int>(nullable: false),
                    VendorInvId = c.Column<string>(),
                    Pnr = c.Column<string>(),
                    ExpectedDatePayment = c.Column<DateTime>(),
                    GDSs = c.Column<int>(nullable: false),
                    GDSUserId = c.Column<string>(),
                    CancellationChargeBefore = c.Column<string>(),
                    CancellationChargeAfter = c.Column<string>(),
                    CancellationDateBefore = c.Column<string>(),
                    CancellationDateAfter = c.Column<string>(),
                    NoShowBefore = c.Column<string>(),
                    NoShowAfter = c.Column<string>(),
                    InvoiceStatusS = c.Column<int>(),
                    PaymentStatus = c.Column<int>(),
                    ExtraCharge = c.Column<double>(nullable: false),
                    PaidByAgent = c.Column<bool>(),
                    PaidToVendor = c.Column<bool>(),
                })
                .PrimaryKey("Invoices_PK", t => t.Id);
            migrationBuilder.CreateIndex("Invoices_AgentId_IX", "dbo.Invoices", "AgentId");
            migrationBuilder.CreateIndex("Invoices_AirlinesId_IX", "dbo.Invoices", "AirlinesId");
            migrationBuilder.CreateIndex("Invoices_ApplicationUserId_IX", "dbo.Invoices", "ApplicationUserId");
            migrationBuilder.CreateIndex("Invoices_VendorId_IX", "dbo.Invoices", "VendorId"); ;

            migrationBuilder.CreateTable(
                "dbo.Vendors",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = c.Column<string>(),
                    Email = c.Column<string>(),
                    Address = c.Column<string>(),
                    Telephone = c.Column<string>(),
                    FaxNo = c.Column<string>(),
                    NetSafi = c.Column<double>(nullable: false),
                    Atol = c.Column<double>(nullable: false),
                    Balance = c.Column<double>(nullable: false),
                    AddedOn = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("Vendors_PK", t => t.Id);
            migrationBuilder.CreateIndex("Vendors_ApplicationUserId_IX", "dbo.Vendors", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.InvoiceNames",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = c.Column<int>(nullable: false),
                    BookingDate = c.Column<DateTime>(),
                    PassengerTypes = c.Column<int>(),
                    Name = c.Column<string>(),
                    TicketNo = c.Column<string>(),
                    Amount = c.Column<double>(nullable: false),
                    CNetFare = c.Column<double>(nullable: false),
                    VNetFare = c.Column<double>(nullable: false),
                    TicketTax = c.Column<double>(nullable: false),
                    VendorCharge = c.Column<double>(nullable: false),
                    Apc = c.Column<double>(nullable: false),
                    Status = c.Column<int>(),
                })
                .PrimaryKey("InvoiceNames_PK", t => t.Id);
            migrationBuilder.CreateIndex("InvoiceNames_InvoiceId_IX", "dbo.InvoiceNames", "InvoiceId"); ;

            migrationBuilder.CreateTable(
                "dbo.InvoicePayments",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = c.Column<int>(nullable: false),
                    AgentId = c.Column<int>(nullable: false),
                    PaymentMethods = c.Column<int>(nullable: false),
                    GeneralLedgerId = c.Column<int>(nullable: false),
                    AgentLedgerId = c.Column<int>(nullable: false),
                    BankAccountLedgerId = c.Column<int>(),
                    Amount = c.Column<double>(nullable: false),
                    Remarks = c.Column<string>(),
                    SysDateTime = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("InvoicePayments_PK", t => t.Id);
            migrationBuilder.CreateIndex("InvoicePayments_InvoiceId_IX", "dbo.InvoicePayments", "InvoiceId");
            migrationBuilder.CreateIndex("InvoicePayments_AgentId_IX", "dbo.InvoicePayments", "AgentId");
            migrationBuilder.CreateIndex("InvoicePayments_GeneralLedgerId_IX", "dbo.InvoicePayments", "GeneralLedgerId");
            migrationBuilder.CreateIndex("InvoicePayments_AgentLedgerId_IX", "dbo.InvoicePayments", "AgentLedgerId");
            migrationBuilder.CreateIndex("InvoicePayments_BankAccountLedgerId_IX", "dbo.InvoicePayments", "BankAccountLedgerId");
            migrationBuilder.CreateIndex("InvoicePayments_ApplicationUserId_IX", "dbo.InvoicePayments", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.InvoicePaymentVendors",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = c.Column<int>(nullable: false),
                    VendorId = c.Column<int>(nullable: false),
                    PaymentMethods = c.Column<int>(nullable: false),
                    GeneralLedgerId = c.Column<int>(),
                    VendorLedgerId = c.Column<int>(nullable: false),
                    BankAccountLedgerId = c.Column<int>(),
                    Amount = c.Column<double>(nullable: false),
                    Remarks = c.Column<string>(),
                    SysDateTime = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("InvoicePaymentVendors_PK", t => t.Id);
            migrationBuilder.CreateIndex("InvoicePaymentVendors_InvoiceId_IX", "dbo.InvoicePaymentVendor", "InvoiceId");
            migrationBuilder.CreateIndex("InvoicePaymentVendors_VendorId_IX", "dbo.InvoicePaymentVendor", "VendorId");
            migrationBuilder.CreateIndex("InvoicePaymentVendors_GeneralLedgerId_IX", "dbo.InvoicePaymentVendor", "GeneralLedgerId");
            migrationBuilder.CreateIndex("InvoicePaymentVendors_VendorLedgerId_IX", "dbo.InvoicePaymentVendor", "VendorLedgerId");
            migrationBuilder.CreateIndex("InvoicePaymentVendors_BankAccountLedgerId_IX", "dbo.InvoicePaymentVendor", "BankAccountLedgerId");
            migrationBuilder.CreateIndex("InvoicePaymentVendors_ApplicationUserId_IX", "dbo.InvoicePaymentVendor", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.VendorLedgers",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    VendorLedgerHeadId = c.Column<int>(nullable: false),
                    GeneralLedgerId = c.Column<int>(),
                    BankAccountLedgerId = c.Column<int>(),
                    VendorId = c.Column<int>(nullable: false),
                    PaymentMethods = c.Column<int>(),
                    Amount = c.Column<double>(nullable: false),
                    Balance = c.Column<double>(nullable: false),
                    Remarks = c.Column<string>(),
                    SystemDate = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("VendorLedgers_PK", t => t.Id);
            migrationBuilder.CreateIndex("VendorLedgers_VendorLedgerHeadId_IX", "dbo.VendorLedgers", "VendorLedgerHeadId");
            migrationBuilder.CreateIndex("VendorLedgers_GeneralLedgerId_IX", "dbo.VendorLedgers", "GeneralLedgerId");
            migrationBuilder.CreateIndex("VendorLedgers_BankAccountLedgerId_IX", "dbo.VendorLedgers", "BankAccountLedgerId");
            migrationBuilder.CreateIndex("VendorLedgers_VendorId_IX", "dbo.VendorLedgers", "VendorId");
            migrationBuilder.CreateIndex("VendorLedgers_ApplicationUserId_IX", "dbo.VendorLedgers", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.VendorLedgerHeads",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    LedgerHead = c.Column<string>(maxLength: 255),
                    LedgerTypes = c.Column<int>(nullable: false),
                    Edit = c.Column<bool>(nullable: false),
                    Status = c.Column<bool>(nullable: false),
                })
                .PrimaryKey("VendorLedgerHeads_PK", t => t.Id);
            migrationBuilder.CreateIndex("VendorLedgersHeads_LedgerHead_IX", "dbo.VendorLedgersHeads", "LedgerHead");

            migrationBuilder.CreateTable(
                "dbo.InvoiceRefunds",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    RefundDate = c.Column<DateTime>(nullable: false),
                    VendorId = c.Column<int>(nullable: false),
                    InvoiceId = c.Column<int>(nullable: false),
                    ProfileName = c.Column<string>(),
                    TicketNo = c.Column<string>(),
                    CustomerFare = c.Column<double>(nullable: false),
                    InvoiceTax = c.Column<double>(nullable: false),
                    InvoiceNetFare = c.Column<double>(nullable: false),
                    UserFare = c.Column<double>(nullable: false),
                    CancellationFee = c.Column<double>(nullable: false),
                    RefundTax = c.Column<double>(nullable: false),
                    CustomerCancellationFee = c.Column<double>(nullable: false),
                    VendorCharge = c.Column<double>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("InvoiceRefunds_PK", t => t.Id);
            migrationBuilder.CreateIndex("InvoiceRefunds_VendorId_IX", "dbo.InvoiceRefunds", "VendorId");
            migrationBuilder.CreateIndex("InvoiceRefunds_InvoiceId_IX", "dbo.InvoiceRefunds", "InvoiceId");
            migrationBuilder.CreateIndex("InvoiceRefunds_ApplicationUserId_IX", "dbo.InvoiceRefunds", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.InvoiceSegments",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = c.Column<int>(nullable: false),
                    AirlinesCode = c.Column<string>(),
                    FlightNo = c.Column<string>(),
                    SegmentClass = c.Column<string>(),
                    DepartureDate = c.Column<string>(),
                    DepartureFrom = c.Column<string>(),
                    DepartureTo = c.Column<string>(),
                    DepartureTime = c.Column<string>(),
                    ArrivalTime = c.Column<string>(),
                    SegmentStatus = c.Column<string>(),
                    SegmentSecondaryStatus = c.Column<string>(),
                    FlightDate = c.Column<string>(),
                })
                .PrimaryKey("InvoiceSegments_PK", t => t.Id);
            migrationBuilder.CreateIndex("InvoiceSegments_InvoiceId_IX", "dbo.InvoiceSegments", "InvoiceId"); ;

            migrationBuilder.CreateTable(
                "dbo.IPBPaymentDetails",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountLedgerId = c.Column<int>(),
                    BankAccountId = c.Column<int>(nullable: false),
                    Remarks = c.Column<string>(),
                    BankDate = c.Column<string>(),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("IPBPaymentDetails_PK", t => t.Id);
            migrationBuilder.CreateIndex("IPBPaymentDetails_BankAccountLedgerId_IX", "dbo.IPBPaymentDetails", "BankAccountLedgerId");
            migrationBuilder.CreateIndex("IPBPaymentDetails_BankAccountId_IX", "dbo.IPBPaymentDetails", "BankAccountId");
            migrationBuilder.CreateIndex("IPBPaymentDetails_ApplicationUserId_IX", "dbo.IPBPaymentDetails", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.IPCCardDetails",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = c.Column<int>(),
                    OtherInvoiceId = c.Column<int>(),
                    InvoicePaymentId = c.Column<int>(),
                    BankAccountId = c.Column<int>(nullable: false),
                    CardNo = c.Column<string>(),
                    CardHolder = c.Column<string>(),
                    ExtraAmount = c.Column<string>(),
                    BankDate = c.Column<string>(),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("IPCCardDetails_PK", t => t.Id);

            migrationBuilder.CreateIndex("IPCCardDetails_InvoiceId_IX", "dbo.IPCCardDetails", "InvoiceId");
            migrationBuilder.CreateIndex("IPCCardDetails_OtherInvoiceId_IX", "dbo.IPCCardDetails", "OtherInvoiceId");
            migrationBuilder.CreateIndex("IPCCardDetails_InvoicePaymentId_IX", "dbo.IPCCardDetails", "InvoicePaymentId");
            migrationBuilder.CreateIndex("IPCCardDetails_BankAccountId_IX", "dbo.IPCCardDetails", "BankAccountId");
            migrationBuilder.CreateIndex("IPCCardDetails_ApplicationUserId_IX", "dbo.IPCCardDetails", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.OtherInvoices",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = c.Column<int>(nullable: false),
                    VendorId = c.Column<int>(nullable: false),
                    OtherInvoiceTypeId = c.Column<int>(nullable: false),
                    Reference = c.Column<string>(),
                    ExpectedPayDate = c.Column<string>(),
                    VendorInvNo = c.Column<string>(),
                    Details = c.Column<string>(),
                    CustomerAgentAmount = c.Column<double>(nullable: false),
                    VendorAmount = c.Column<double>(nullable: false),
                    CustomerAgentPaid = c.Column<bool>(nullable: false),
                    VendorPaid = c.Column<bool>(nullable: false),
                    CreatedOn = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                    Status = c.Column<int>(nullable: false),
                })
                .PrimaryKey("OtherInvoices_PK", t => t.Id);
            migrationBuilder.CreateIndex("OtherInvoices_AgentId_IX", "dbo.OtherInvoices", "AgentId");
            migrationBuilder.CreateIndex("OtherInvoices_VendorId_IX", "dbo.OtherInvoices", "VendorId");
            migrationBuilder.CreateIndex("OtherInvoices_OtherInvoiceTypeId_IX", "dbo.OtherInvoices", "OtherInvoiceTypeId");
            migrationBuilder.CreateIndex("OtherInvoices_ApplicationUserId_IX", "dbo.OtherInvoices", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.OtherInvoiceTypes",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceType = c.Column<string>(),
                    CreatedOn = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("OtherInvoiceTypes_PK", t => t.Id);
            migrationBuilder.CreateIndex("OtherInvoiceTypes_ApplicationUserId_IX", "dbo.OtherInvoiceTypes", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.IPChequeDetails",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = c.Column<int>(),
                    OtherInvoiceId = c.Column<int>(),
                    InvoicePaymentId = c.Column<int>(),
                    GeneralLedgerId = c.Column<int>(),
                    BankNames = c.Column<int>(nullable: false),
                    AccountNo = c.Column<string>(),
                    ChequeNo = c.Column<string>(),
                    SortCode = c.Column<string>(),
                    Amount = c.Column<double>(nullable: false),
                    Remarks = c.Column<string>(),
                    SysCreateDate = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                    Status = c.Column<int>(nullable: false),
                    BulkPayment = c.Column<bool>(),
                    ProfileType = c.Column<int>(),
                })
                .PrimaryKey("IPChequeDetails_PK", t => t.Id);
            migrationBuilder.CreateIndex("IPChequeDetails_InvoiceId_IX", "dbo.IPChequeDetails", "InvoiceId");
            migrationBuilder.CreateIndex("IPChequeDetails_OtherInvoiceId_IX", "dbo.IPChequeDetails", "OtherInvoiceId");
            migrationBuilder.CreateIndex("IPChequeDetails_InvoicePaymentId_IX", "dbo.IPChequeDetails", "InvoicePaymentId");
            migrationBuilder.CreateIndex("IPChequeDetails_GeneralLedgerId_IX", "dbo.IPChequeDetails", "GeneralLedgerId");
            migrationBuilder.CreateIndex("IPChequeDetails_ApplicationUserId_IX", "dbo.IPChequeDetails", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.IPDCardDetails",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = c.Column<int>(),
                    OtherInvoiceId = c.Column<int>(),
                    InvoicePaymentId = c.Column<int>(),
                    BankAccountId = c.Column<int>(nullable: false),
                    CardNo = c.Column<string>(),
                    CardHolder = c.Column<string>(),
                    ExtraAmount = c.Column<string>(),
                    BankDate = c.Column<string>(),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("IPDCardDetails_PK", t => t.Id);
            migrationBuilder.CreateIndex("IPDCardDetails_InvoiceId_IX", "dbo.IPDCardDetails", "InvoiceId");
            migrationBuilder.CreateIndex("IPDCardDetails_OtherInvoiceId_IX", "dbo.IPDCardDetails", "OtherInvoiceId");
            migrationBuilder.CreateIndex("IPDCardDetails_InvoicePaymentId_IX", "dbo.IPDCardDetails", "InvoicePaymentId");
            migrationBuilder.CreateIndex("IPDCardDetails_BankAccountId_IX", "dbo.IPDCardDetails", "BankAccountId");
            migrationBuilder.CreateIndex("IPDCardDetails_ApplicationUserId_IX", "dbo.IPDCardDetails", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.OtherInvoiceLogs",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    OtherInvoiceId = c.Column<int>(nullable: false),
                    Remarks = c.Column<string>(),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                    SysDateTime = c.Column<DateTime>(nullable: false),
                })
                .PrimaryKey("OtherInvoiceLogs_PK", t => t.Id);
            migrationBuilder.CreateIndex("OtherInvoiceLogs_OtherInvoiceId_IX", "dbo.OtherInvoiceLogs", "OtherInvoiceId");
            migrationBuilder.CreateIndex("OtherInvoiceLogs_ApplicationUserId_IX", "dbo.OtherInvoiceLog", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.OtherInvoicePayments",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    OtherInvoiceId = c.Column<int>(nullable: false),
                    AgentId = c.Column<int>(nullable: false),
                    PaymentMethods = c.Column<int>(nullable: false),
                    GeneralLedgerId = c.Column<int>(nullable: false),
                    AgentLedgerId = c.Column<int>(nullable: false),
                    BankAccountLedgerId = c.Column<int>(),
                    Amount = c.Column<double>(nullable: false),
                    Remarks = c.Column<string>(),
                    SysDateTime = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("OtherInvoicePayments_PK", t => t.Id);
            migrationBuilder.CreateIndex("OtherInvoicePayments_OtherInvoiceId_IX", "dbo.OtherInvoicePayments", "OtherInvoiceId");
            migrationBuilder.CreateIndex("OtherInvoicePayments_AgentId_IX", "dbo.OtherInvoicePayments", "AgentId");
            migrationBuilder.CreateIndex("OtherInvoicePayments_GeneralLedgerId_IX", "dbo.OtherInvoicePayments", "GeneralLedgerId");
            migrationBuilder.CreateIndex("OtherInvoicePayments_AgentLedgerId_IX", "dbo.OtherInvoicePayments", "AgentLedgerId");
            migrationBuilder.CreateIndex("OtherInvoicePayments_BankAccountLedgerId_IX", "dbo.OtherInvoicePayments", "BankAccountLedgerId");
            migrationBuilder.CreateIndex("OtherInvoicePayments_ApplicationUserId_IX", "dbo.OtherInvoicePayments", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.OtherInvoicePaymentVendors",
                c => new
                {
                    Id = c.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    OtherInvoiceId = c.Column<int>(nullable: false),
                    VendorId = c.Column<int>(nullable: false),
                    PaymentMethods = c.Column<int>(nullable: false),
                    GeneralLedgerId = c.Column<int>(),
                    VendorLedgerId = c.Column<int>(nullable: false),
                    BankAccountLedgerId = c.Column<int>(),
                    Amount = c.Column<double>(nullable: false),
                    Remarks = c.Column<string>(),
                    SysDateTime = c.Column<DateTime>(nullable: false),
                    ApplicationUserId = c.Column<string>(maxLength: 128),
                })
                .PrimaryKey("OtherInvoicePaymentVendors_PK", t => t.Id);
            migrationBuilder.CreateIndex("OtherInvoicePaymentVendors_OtherInvoiceId_IX", "dbo.OtherInvoicePaymentVendors", "OtherInvoiceId");
            migrationBuilder.CreateIndex("OtherInvoicePaymentVendors_VendorId_IX", "dbo.OtherInvoicePaymentVendors", "VendorId");
            migrationBuilder.CreateIndex("OtherInvoicePaymentVendors_GeneralLedgerId_IX", "dbo.OtherInvoicePaymentVendors", "GeneralLedgerId");
            migrationBuilder.CreateIndex("OtherInvoicePaymentVendors_VendorLedgerId_IX", "dbo.OtherInvoicePaymentVendors", "VendorLedgerId");
            migrationBuilder.CreateIndex("OtherInvoicePaymentVendors_BankAccountLedgerId_IX", "dbo.OtherInvoicePaymentVendors", "BankAccountLedgerId");
            migrationBuilder.CreateIndex("OtherInvoicePaymentVendors_ApplicationUserId_IX", "dbo.OtherInvoicePaymentVendors", "ApplicationUserId"); ;

            migrationBuilder.CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.Column<string>(nullable: false, maxLength: 128),
                    Name = c.Column<string>(nullable: false, maxLength: 256),
                })
                .PrimaryKey("AspNetRoles_PK", t => t.Id);
            migrationBuilder.CreateIndex("RoleNameIndex", "AspNetRoles", "Name", unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePaymentVendors", "VendorId", "dbo.Vendors");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePaymentVendors", "VendorLedgerId", "dbo.VendorLedgers");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePaymentVendors", "OtherInvoiceId", "dbo.OtherInvoices");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePaymentVendors", "GeneralLedgerId", "dbo.GeneralLedgers");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePaymentVendors", "BankAccountLedgerId", "dbo.BankAccountLedgers");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePaymentVendors", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePayments", "OtherInvoiceId", "dbo.OtherInvoices");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePayments", "GeneralLedgerId", "dbo.GeneralLedgers");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePayments", "BankAccountLedgerId", "dbo.BankAccountLedgers");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePayments", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePayments", "AgentId", "dbo.Agents");
            migrationBuilder.DropForeignKey("dbo.OtherInvoicePayments", "AgentLedgerId", "dbo.AgentLedgers");
            migrationBuilder.DropForeignKey("dbo.OtherInvoiceLogs", "OtherInvoiceId", "dbo.OtherInvoices");
            migrationBuilder.DropForeignKey("dbo.OtherInvoiceLogs", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.IPDCardDetails", "OtherInvoiceId", "dbo.OtherInvoices");
            migrationBuilder.DropForeignKey("dbo.IPDCardDetails", "InvoiceId", "dbo.Invoices");
            migrationBuilder.DropForeignKey("dbo.IPDCardDetails", "InvoicePaymentId", "dbo.InvoicePayments");
            migrationBuilder.DropForeignKey("dbo.IPDCardDetails", "BankAccountId", "dbo.BankAccounts");
            migrationBuilder.DropForeignKey("dbo.IPDCardDetails", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.IPChequeDetails", "OtherInvoiceId", "dbo.OtherInvoices");
            migrationBuilder.DropForeignKey("dbo.IPChequeDetails", "InvoiceId", "dbo.Invoices");
            migrationBuilder.DropForeignKey("dbo.IPChequeDetails", "InvoicePaymentId", "dbo.InvoicePayments");
            migrationBuilder.DropForeignKey("dbo.IPChequeDetails", "GeneralLedgerId", "dbo.GeneralLedgers");
            migrationBuilder.DropForeignKey("dbo.IPChequeDetails", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.IPCCardDetails", "OtherInvoiceId", "dbo.OtherInvoices");
            migrationBuilder.DropForeignKey("dbo.OtherInvoices", "VendorId", "dbo.Vendors");
            migrationBuilder.DropForeignKey("dbo.OtherInvoices", "OtherInvoiceTypeId", "dbo.OtherInvoiceTypes");
            migrationBuilder.DropForeignKey("dbo.OtherInvoiceTypes", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.OtherInvoices", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.OtherInvoices", "AgentId", "dbo.Agents");
            migrationBuilder.DropForeignKey("dbo.IPCCardDetails", "InvoiceId", "dbo.Invoices");
            migrationBuilder.DropForeignKey("dbo.IPCCardDetails", "InvoicePaymentId", "dbo.InvoicePayments");
            migrationBuilder.DropForeignKey("dbo.IPCCardDetails", "BankAccountId", "dbo.BankAccounts");
            migrationBuilder.DropForeignKey("dbo.IPCCardDetails", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.IPBPaymentDetails", "BankAccountId", "dbo.BankAccounts");
            migrationBuilder.DropForeignKey("dbo.IPBPaymentDetails", "BankAccountLedgerId", "dbo.BankAccountLedgers");
            migrationBuilder.DropForeignKey("dbo.IPBPaymentDetails", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.InvoiceSegments", "InvoiceId", "dbo.Invoices");
            migrationBuilder.DropForeignKey("dbo.InvoiceRefunds", "VendorId", "dbo.Vendors");
            migrationBuilder.DropForeignKey("dbo.InvoiceRefunds", "InvoiceId", "dbo.Invoices");
            migrationBuilder.DropForeignKey("dbo.InvoiceRefunds", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.InvoicePaymentVendors", "VendorId", "dbo.Vendors");
            migrationBuilder.DropForeignKey("dbo.InvoicePaymentVendors", "VendorLedgerId", "dbo.VendorLedgers");
            migrationBuilder.DropForeignKey("dbo.VendorLedgers", "VendorId", "dbo.Vendors");
            migrationBuilder.DropForeignKey("dbo.VendorLedgers", "VendorLedgerHeadId", "dbo.VendorLedgerHeads");
            migrationBuilder.DropForeignKey("dbo.VendorLedgers", "GeneralLedgerId", "dbo.GeneralLedgers");
            migrationBuilder.DropForeignKey("dbo.VendorLedgers", "BankAccountLedgerId", "dbo.BankAccountLedgers");
            migrationBuilder.DropForeignKey("dbo.VendorLedgers", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.InvoicePaymentVendors", "InvoiceId", "dbo.Invoices");
            migrationBuilder.DropForeignKey("dbo.InvoicePaymentVendors", "GeneralLedgerId", "dbo.GeneralLedgers");
            migrationBuilder.DropForeignKey("dbo.InvoicePaymentVendors", "BankAccountLedgerId", "dbo.BankAccountLedgers");
            migrationBuilder.DropForeignKey("dbo.InvoicePaymentVendors", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.InvoicePayments", "InvoiceId", "dbo.Invoices");
            migrationBuilder.DropForeignKey("dbo.InvoicePayments", "GeneralLedgerId", "dbo.GeneralLedgers");
            migrationBuilder.DropForeignKey("dbo.InvoicePayments", "BankAccountLedgerId", "dbo.BankAccountLedgers");
            migrationBuilder.DropForeignKey("dbo.InvoicePayments", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.InvoicePayments", "AgentId", "dbo.Agents");
            migrationBuilder.DropForeignKey("dbo.InvoicePayments", "AgentLedgerId", "dbo.AgentLedgers");
            migrationBuilder.DropForeignKey("dbo.InvoiceNames", "InvoiceId", "dbo.Invoices");
            migrationBuilder.DropForeignKey("dbo.InvoiceLogs", "InvoiceId", "dbo.Invoices");
            migrationBuilder.DropForeignKey("dbo.Invoices", "VendorId", "dbo.Vendors");
            migrationBuilder.DropForeignKey("dbo.Vendors", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.Invoices", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.Invoices", "AirlinesId", "dbo.Airlines");
            migrationBuilder.DropForeignKey("dbo.Invoices", "AgentId", "dbo.Agents");
            migrationBuilder.DropForeignKey("dbo.InvoiceLogs", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.AgentLedgers", "GeneralLedgerId", "dbo.GeneralLedgers");
            migrationBuilder.DropForeignKey("dbo.AgentLedgers", "BankAccountLedgerId", "dbo.BankAccountLedgers");
            migrationBuilder.DropForeignKey("dbo.BankAccountLedgers", "GeneralLedgerId", "dbo.GeneralLedgers");
            migrationBuilder.DropForeignKey("dbo.GeneralLedgers", "GeneralLedgerHeadId", "dbo.GeneralLedgerHeads");
            migrationBuilder.DropForeignKey("dbo.GeneralLedgers", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.BankAccountLedgers", "BankAccountId", "dbo.BankAccounts");
            migrationBuilder.DropForeignKey("dbo.BankAccounts", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.BankAccountLedgers", "BankAccountLedgerHeadId", "dbo.BankAccountLedgerHeads");
            migrationBuilder.DropForeignKey("dbo.BankAccountLedgerHeads", "GeneralLedgerHeadId", "dbo.GeneralLedgerHeads");
            migrationBuilder.DropForeignKey("dbo.BankAccountLedgers", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.AgentLedgers", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.AgentLedgers", "AgentId", "dbo.Agents");
            migrationBuilder.DropForeignKey("dbo.Agents", "ApplicationUserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            migrationBuilder.DropForeignKey("dbo.AgentLedgers", "AgentLedgerHeadId", "dbo.AgentLedgerHeads");
            migrationBuilder.DropIndex("dbo.AspNetRoles", "RoleNameIndex");

            migrationBuilder.DropIndex("", "");
            migrationBuilder.DropIndex("OtherInvoicePaymentVendors_ApplicationUserId_IX", "dbo.OtherInvoicePaymentVendors");
            migrationBuilder.DropIndex("OtherInvoicePaymentVendors_BankAccountLedgerId_IX", "dbo.OtherInvoicePaymentVendors");
            migrationBuilder.DropIndex("OtherInvoicePaymentVendors_VendorLedgerId_IX", "dbo.OtherInvoicePaymentVendors");
            migrationBuilder.DropIndex("OtherInvoicePaymentVendors_GeneralLedgerId_IX", "dbo.OtherInvoicePaymentVendors");
            migrationBuilder.DropIndex("OtherInvoicePaymentVendors_VendorId_IX", "dbo.OtherInvoicePaymentVendors");
            migrationBuilder.DropIndex("OtherInvoicePaymentVendors_OtherInvoiceId_IX", "dbo.OtherInvoicePaymentVendors");
            migrationBuilder.DropIndex("OtherInvoicePayments_ApplicationUserId_IX", "dbo.OtherInvoicePayments");
            migrationBuilder.DropIndex("OtherInvoicePayments_BankAccountLedgerId_IX", "dbo.OtherInvoicePayments");
            migrationBuilder.DropIndex("OtherInvoicePayments_AgentLedgerId_IX", "dbo.OtherInvoicePayments");
            migrationBuilder.DropIndex("OtherInvoicePayments_GeneralLedgerId_IX", "dbo.OtherInvoicePayments");
            migrationBuilder.DropIndex("OtherInvoicePayments_AgentId_IX", "dbo.OtherInvoicePayments");
            migrationBuilder.DropIndex("OtherInvoicePayments_OtherInvoiceId_IX", "dbo.OtherInvoicePayments");
            migrationBuilder.DropIndex("OtherInvoiceLogs_ApplicationUserId_IX", "dbo.OtherInvoiceLogs");
            migrationBuilder.DropIndex("OtherInvoiceLogs_OtherInvoiceId_IX", "dbo.OtherInvoiceLogs");
            migrationBuilder.DropIndex("IPDCardDetails_ApplicationUserId_IX", "dbo.IPDCardDetails");
            migrationBuilder.DropIndex("IPDCardDetails_BankAccountId_IX", "dbo.IPDCardDetails");
            migrationBuilder.DropIndex("IPDCardDetails_InvoicePaymentId_IX", "dbo.IPDCardDetails");
            migrationBuilder.DropIndex("IPDCardDetails_OtherInvoiceId_IX", "dbo.IPDCardDetails");
            migrationBuilder.DropIndex("IPDCardDetails_InvoiceId_IX", "dbo.IPDCardDetails");
            migrationBuilder.DropIndex("IPChequeDetails_ApplicationUserId_IX", "dbo.IPChequeDetails");
            migrationBuilder.DropIndex("IPChequeDetails_GeneralLedgerId_IX", "dbo.IPChequeDetails");
            migrationBuilder.DropIndex("IPChequeDetails_InvoicePaymentId_IX", "dbo.IPChequeDetails");
            migrationBuilder.DropIndex("IPChequeDetails_OtherInvoiceId_IX", "dbo.IPChequeDetails");
            migrationBuilder.DropIndex("IPChequeDetails_InvoiceId_IX", "dbo.IPChequeDetails");
            migrationBuilder.DropIndex("OtherInvoiceTypes_ApplicationUserId_IX", "dbo.OtherInvoiceTypes");
            migrationBuilder.DropIndex("OtherInvoices_ApplicationUserId_IX", "dbo.OtherInvoices");
            migrationBuilder.DropIndex("OtherInvoices_OtherInvoiceTypeId_IX", "dbo.OtherInvoices");
            migrationBuilder.DropIndex("OtherInvoices_VendorId_IX", "dbo.OtherInvoices");
            migrationBuilder.DropIndex("OtherInvoices_AgentId_IX", "dbo.OtherInvoices");
            migrationBuilder.DropIndex("IPCCardDetails_ApplicationUserId_IX", "dbo.IPCCardDetails");
            migrationBuilder.DropIndex("IPCCardDetails_BankAccountId_IX", "dbo.IPCCardDetails");
            migrationBuilder.DropIndex("IPCCardDetails_InvoicePaymentId_IX", "dbo.IPCCardDetails");
            migrationBuilder.DropIndex("IPCCardDetails_OtherInvoiceId_IX", "dbo.IPCCardDetails");
            migrationBuilder.DropIndex("IPCCardDetails_InvoiceId_IX", "dbo.IPCCardDetails");
            migrationBuilder.DropIndex("IPBPaymentDetails_ApplicationUserId_IX", "dbo.IPBPaymentDetails");
            migrationBuilder.DropIndex("IPBPaymentDetails_BankAccountId_IX", "dbo.IPBPaymentDetails");
            migrationBuilder.DropIndex("IPBPaymentDetails_BankAccountLedgerId_IX", "dbo.IPBPaymentDetails");
            migrationBuilder.DropIndex("InvoiceSegments_InvoiceId_IX", "dbo.InvoiceSegments");
            migrationBuilder.DropIndex("InvoiceRefunds_ApplicationUserId_IX", "dbo.InvoiceRefunds");
            migrationBuilder.DropIndex("InvoiceRefunds_InvoiceId_IX", "dbo.InvoiceRefunds");
            migrationBuilder.DropIndex("InvoiceRefunds_VendorId_IX", "dbo.InvoiceRefunds");
            migrationBuilder.DropIndex("VendorLedgerHeads_LedgerHead_IX", "dbo.VendorLedgerHeads");
            migrationBuilder.DropIndex("VendorLedgers_ApplicationUserId_IX", "dbo.VendorLedgers");
            migrationBuilder.DropIndex("VendorLedgers_VendorId_IX", "dbo.VendorLedgers");
            migrationBuilder.DropIndex("VendorLedgers_BankAccountLedgerId_IX", "dbo.VendorLedgers");
            migrationBuilder.DropIndex("VendorLedgers_GeneralLedgerId_IX", "dbo.VendorLedgers");
            migrationBuilder.DropIndex("VendorLedgers_VendorLedgerHeadId_IX", "dbo.VendorLedgers");
            migrationBuilder.DropIndex("InvoicePaymentVendors_ApplicationUserId_IX", "dbo.InvoicePaymentVendors");
            migrationBuilder.DropIndex("InvoicePaymentVendors_BankAccountLedgerId_IX", "dbo.InvoicePaymentVendors");
            migrationBuilder.DropIndex("InvoicePaymentVendors_VendorLedgerId_IX", "dbo.InvoicePaymentVendors");
            migrationBuilder.DropIndex("InvoicePaymentVendors_GeneralLedgerId_IX", "dbo.InvoicePaymentVendors");
            migrationBuilder.DropIndex("InvoicePaymentVendors_VendorId_IX", "dbo.InvoicePaymentVendors");
            migrationBuilder.DropIndex("InvoicePaymentVendors_InvoiceId_IX", "dbo.InvoicePaymentVendors");
            migrationBuilder.DropIndex("InvoicePayments_ApplicationUserId_IX", "dbo.InvoicePayments");
            migrationBuilder.DropIndex("InvoicePayments_BankAccountLedgerId_IX", "dbo.InvoicePayments");
            migrationBuilder.DropIndex("InvoicePayments_AgentLedgerId_IX", "dbo.InvoicePayments");
            migrationBuilder.DropIndex("InvoicePayments_GeneralLedgerId_IX", "dbo.InvoicePayments");
            migrationBuilder.DropIndex("InvoicePayments_AgentId_IX", "dbo.InvoicePayments");
            migrationBuilder.DropIndex("InvoicePayments_InvoiceId_IX", "dbo.InvoicePayments");
            migrationBuilder.DropIndex("InvoiceNames_InvoiceId_IX", "dbo.InvoiceNames");
            migrationBuilder.DropIndex("Vendors_ApplicationUserId_IX", "dbo.Vendors");
            migrationBuilder.DropIndex("Invoices_VendorId_IX", "dbo.Invoices");
            migrationBuilder.DropIndex("Invoices_ApplicationUserId_IX", "dbo.Invoices");
            migrationBuilder.DropIndex("Invoices_AirlinesId_IX", "dbo.Invoices");
            migrationBuilder.DropIndex("Invoices_AgentId_IX", "dbo.Invoices");
            migrationBuilder.DropIndex("InvoiceLogs_ApplicationUserId_IX", "dbo.InvoiceLogs");
            migrationBuilder.DropIndex("InvoiceLogs_InvoiceId_IX", "dbo.InvoiceLogs");
            migrationBuilder.DropIndex("Airlines_Code_IX", "dbo.Airlines");
            migrationBuilder.DropIndex("Airlines_Name_IX", "dbo.Airlines");
            migrationBuilder.DropIndex("GeneralLedgers_ApplicationUserId_IX", "dbo.GeneralLedgers");
            migrationBuilder.DropIndex("GeneralLedgers_GeneralLedgerHeadId_IX", "dbo.GeneralLedgers");
            migrationBuilder.DropIndex("BankAccounts_ApplicationUserId_IX", "dbo.BankAccounts");
            migrationBuilder.DropIndex("BankAccountLedgerHeads_GeneralLedgerHeadId_IX", "dbo.BankAccountLedgerHeads");
            migrationBuilder.DropIndex("dbo.BankAccountLedgerHeads", "IX_FirstAndSecond");
            migrationBuilder.DropIndex("BankAccountLedgers_ApplicationUserId_IX", "dbo.BankAccountLedgers");
            migrationBuilder.DropIndex("BankAccountLedgers_GeneralLedgerId_IX", "dbo.BankAccountLedgers");
            migrationBuilder.DropIndex("BankAccountLedgers_BankAccountLedgerHeadId_IX", "dbo.BankAccountLedgers");
            migrationBuilder.DropIndex("BankAccountLedgers_BankAccountId_IX", "dbo.BankAccountLedgers");
            migrationBuilder.DropIndex("AspNetUserRoles_RoleId_IX", "dbo.AspNetUserRoles");
            migrationBuilder.DropIndex("AspNetUserRoles_UserId_IX", "dbo.AspNetUserRoles");
            migrationBuilder.DropIndex("AspNetUserLogins_UserId_IX", "dbo.AspNetUserLogins");
            migrationBuilder.DropIndex("AspNetUserClaims_UserId_IX", "dbo.AspNetUserClaims");
            migrationBuilder.DropIndex("dbo.AspNetUsers", "UserNameIndex");
            migrationBuilder.DropIndex("AspNetUsers_NationalId_IX", "dbo.AspNetUsers");
            migrationBuilder.DropIndex("AspNetUsers_MobileNo_IX", "dbo.AspNetUsers");
            migrationBuilder.DropIndex("Agents_ApplicationUserId_IX", "dbo.Agents");
            migrationBuilder.DropIndex("AgentLedgers_ApplicationUserId_IX", "dbo.AgentLedgers");
            migrationBuilder.DropIndex("AgentLedgers_BankAccountLedgerId_IX", "dbo.AgentLedgers");
            migrationBuilder.DropIndex("AgentLedgers_GeneralLedgerId_IX", "dbo.AgentLedgers");
            migrationBuilder.DropIndex("AgentLedgers_AgentId_IX", "dbo.AgentLedgers");
            migrationBuilder.DropIndex("AgentLedgers_AgentLedgerHeadId_IX", "dbo.AgentLedgers");
            migrationBuilder.DropIndex("AgentLedgerHeads_LedgerHead_IX", "dbo.AgentLedgerHeads");
            migrationBuilder.DropTable("dbo.AspNetRoles");
            migrationBuilder.DropTable("dbo.OtherInvoicePaymentVendors");
            migrationBuilder.DropTable("dbo.OtherInvoicePayments");
            migrationBuilder.DropTable("dbo.OtherInvoiceLogs");
            migrationBuilder.DropTable("dbo.IPDCardDetails");
            migrationBuilder.DropTable("dbo.IPChequeDetails");
            migrationBuilder.DropTable("dbo.OtherInvoiceTypes");
            migrationBuilder.DropTable("dbo.OtherInvoices");
            migrationBuilder.DropTable("dbo.IPCCardDetails");
            migrationBuilder.DropTable("dbo.IPBPaymentDetails");
            migrationBuilder.DropTable("dbo.InvoiceSegments");
            migrationBuilder.DropTable("dbo.InvoiceRefunds");
            migrationBuilder.DropTable("dbo.VendorLedgerHeads");
            migrationBuilder.DropTable("dbo.VendorLedgers");
            migrationBuilder.DropTable("dbo.InvoicePaymentVendors");
            migrationBuilder.DropTable("dbo.InvoicePayments");
            migrationBuilder.DropTable("dbo.InvoiceNames");
            migrationBuilder.DropTable("dbo.Vendors");
            migrationBuilder.DropTable("dbo.Invoices");
            migrationBuilder.DropTable("dbo.InvoiceLogs");
            migrationBuilder.DropTable("dbo.CompanyInfoes");
            migrationBuilder.DropTable("dbo.CashInHands");
            migrationBuilder.DropTable("dbo.AirportCodes");
            migrationBuilder.DropTable("dbo.Airlines");
            migrationBuilder.DropTable("dbo.GeneralLedgers");
            migrationBuilder.DropTable("dbo.BankAccounts");
            migrationBuilder.DropTable("dbo.GeneralLedgerHeads");
            migrationBuilder.DropTable("dbo.BankAccountLedgerHeads");
            migrationBuilder.DropTable("dbo.BankAccountLedgers");
            migrationBuilder.DropTable("dbo.AspNetUserRoles");
            migrationBuilder.DropTable("dbo.AspNetUserLogins");
            migrationBuilder.DropTable("dbo.AspNetUserClaims");
            migrationBuilder.DropTable("dbo.AspNetUsers");
            migrationBuilder.DropTable("dbo.Agents");
            migrationBuilder.DropTable("dbo.AgentLedgers");
            migrationBuilder.DropTable("dbo.AgentLedgerHeads");
        }
    }
}
