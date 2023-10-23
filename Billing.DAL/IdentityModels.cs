using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Billing.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

namespace Billing.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Airlines> Airliness { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<AgentLedger> AgentLedgers { get; set; }

        public DbSet<AgentLedgerHead> AgentLedgerHeads { get; set; }

        public DbSet<AirportCode> AirportCodes { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<BankAccountLedger> BankAccountLedgers { get; set; }

        public DbSet<BankAccountLedgerHead> BankAccountLedgerHeads { get; set; }

        public DbSet<CashInHand> CashInHands { get; set; }

        public DbSet<CompanyInfo> CompanyInfos { get; set; }

        public DbSet<GeneralLedger> GeneralLedgers { get; set; }

        public DbSet<GeneralLedgerHead> GeneralLeaderHeads { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceLog> InvoiceLogs { get; set; }

        public DbSet<InvoiceName> InvoiceNames { get; set; }

        public DbSet<InvoicePayment> InvoicePayments { get; set; }

        public DbSet<InvoicePaymentVendor> InvoicePaymentVendors { get; set; }

        public DbSet<InvoiceRefund> InvoiceRefunds { get; set; }

        public DbSet<InvoiceSegment> InvoiceSegments { get; set; }

        public DbSet<IPBPaymentDetail> IPBPaymentDetails { get; set; }

        public DbSet<IPCCardDetail> IPCCardDetails { get; set; }

        public DbSet<IPChequeDetail> IPChequeDetails { get; set; }

        public DbSet<IPDCardDetail> IPDCardDetails { get; set; }

        public DbSet<OtherInvoice> OtherInvoices { get; set; }

        public DbSet<OtherInvoiceLog> OtherInvoiceLogs { get; set; }

        public DbSet<OtherInvoicePayment> OtherInvoicePayments { get; set; }

        public DbSet<OtherInvoicePaymentVendor> OtherInvoicePaymentVendors { get; set; }

        public DbSet<OtherInvoiceType> OtherInvoiceTypes { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<VendorLedger> VendorLedgers { get; set; }

        public DbSet<VendorLedgerHead> VendorLedgerHeads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            /* Use Configuration from static ConfigurationManager to access connection string in appsettings.json. Example below: optionsBuilder.UseSqlServer(ConfigurationManager.Configuration.GetConnectionString("CONNECTIONSTRINGNAME")); */
            optionsBuilder.UseSqlServer(ConfigurationManager.Configuration.GetConnectionString("BillingCString"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}