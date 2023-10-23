namespace Billing.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Billing.DAL;
    using Billing.DAL.Helpers;
    using Billing.DAL.Parameters;
    using Billing.Entities;
    using Billing.ViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.AspNetCore.Mvc;
    using Vereyon.Web;

    //[Authorize]
    public class BanksController : Controller
    {
        private readonly ApplicationDbContext db;
        public BanksController(ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;
        }
        public ActionResult Index()
        {
            List<BankAccount> accounts = new BankDA().GetBankAccountList();
            return View(accounts);
        }

        public ActionResult AddBank()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBank(AddBankViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                InsertNewBankAccount Obj = new InsertNewBankAccount();
                Obj.BankNames = (int)model.BankNames;
                Obj.AccountNames = model.AccountNames;
                Obj.AccountNo = model.AccountNo;
                Obj.Balance = model.Balance;
                Obj.UserId = User.Identity.Name;
                new SearchDA().InsertNewBankAccount(Obj);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Index", "Banks");
        }

        public ActionResult BankLedger(int? id, string BankName)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<BankAccountLedger> baLedger = new List<BankAccountLedger>();
            string locBankName = string.Empty;
            string locAccountName = string.Empty;
            try
            {
                DateTime KeyDate = DateTime.Now;
                locBankName = BankHelper.getBankName(BankName);
                locAccountName = db.BankAccounts.Find(id).AccountNames.ToString();
                baLedger = db.BankAccountLedgers.Where(e => e.BankAccountId == id).ToList();
            }
            catch (Exception)
            {
            }

            ViewBag.AcName = locAccountName;
            ViewBag.BankName = locBankName;
            return View(baLedger);
        }

        public ActionResult LedgerHead()
        {
            List<BankAccountLedgerHead> baLHeadLst = new BankDA().GetBankLedgerHeadList();
            return View(baLHeadLst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LedgerHead(BankAccountLedgerHead model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                BankAccountLedgerHead obj = new BankAccountLedgerHead();
                obj.LedgerHead = model.LedgerHead;
                obj.LedgerTypes = model.LedgerTypes;
                new BankDA().InsertNewBankLedgerHead(obj);
                return RedirectToAction("LedgerHead", "Banks");
            }
        }

        public ActionResult BankDeposit()
        {
            BankDepositViewModel model = new BankDepositViewModel();
            model.BankAccountLedgerHeads = db.BankAccountLedgerHeads.Where(a => a.Editable == true && a.Status == true && a.LedgerTypes == LedgerType.Credit).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BankDeposit(BankDepositViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("BankDeposit", "Banks");
            }

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    bool status = false;
                    int TransactionMethod = (int)model.TransactionMethod;
#region Bank Deposit - Payment Method * Cash
                    if (TransactionMethod == 1)
                    {
                        BankDepositCashVoucher Obj = new BankDepositCashVoucher();
                        Obj.Amount = model.Amount;
                        Obj.BankAccountId = model.BankAccountId;
                        Obj.BankLedgerHeadId = model.BankAccountLedgerHeadId;
                        Obj.Notes = model.Notes;
                        Obj.UserID = User.Identity.Name;
                        Obj.LedgerDate = model.LedgerDate;
                        status = new BankDA().InsertBankDepositCashVoucher(Obj);
                    }
#endregion
#region Bank Deposit - Payment Method * Cheque
                    else if (TransactionMethod == 2)
                    {
                        BankDepositChequeVoucher Obj = new BankDepositChequeVoucher();
                        Obj.Amount = model.Amount;
                        Obj.BankAccountId = model.BankAccountId;
                        Obj.BankOfChequeId = (int)model.BankOfChequeId;
                        Obj.ChequeNo = model.ChequeNo;
                        Obj.AccountNo = model.AccountNo;
                        Obj.SortCode = model.SortCode;
                        Obj.Notes = model.Notes;
                        Obj.UserID = User.Identity.Name;
                        Obj.LedgerDate = model.LedgerDate;
                        Obj.ChequeStauts = (int)ChequeStatus.Floating;
                        status = new BankDA().InsertBankDepositChequeVoucher(Obj);
                    }
#endregion
#region Bank Deposit - Payment Method * Credit Card
                    else if (TransactionMethod == 3)
                    {
                        BankDepositCreditCardVoucher Obj = new BankDepositCreditCardVoucher();
                        Obj.Amount = model.Amount;
                        Obj.BankAccountId = model.BankAccountId;
                        Obj.BankDate = model.BankDate;
                        Obj.CardHolder = model.CardHolderName;
                        Obj.CardNo = model.CreditCardNo;
                        Obj.ExtraAmount = model.ExtraAmount;
                        Obj.LedgerDate = model.LedgerDate;
                        Obj.LedgerHeadId = model.BankAccountLedgerHeadId;
                        Obj.Notes = model.Notes;
                        Obj.UserID = User.Identity.Name;
                        status = new BankDA().InsertBankDepositCreditCardVoucher(Obj);
                    }
#endregion
#region Bank Deposit - Payment Method * Debit Card
                    else if (TransactionMethod == 4)
                    {
                        BankDepositDebitCardVoucher Obj = new BankDepositDebitCardVoucher();
                        Obj.Amount = model.Amount;
                        Obj.BankAccountId = model.BankAccountId;
                        Obj.BankDate = model.BankDate;
                        Obj.CardHolder = model.CardHolderName;
                        Obj.CardNo = model.CreditCardNo;
                        Obj.ExtraAmount = model.ExtraAmount;
                        Obj.LedgerDate = model.LedgerDate;
                        Obj.LedgerHeadId = model.BankAccountLedgerHeadId;
                        Obj.Notes = model.Notes;
                        Obj.UserID = User.Identity.Name;
                        status = new BankDA().InsertBankDepositDebitCardVoucher(Obj);
                    }
#endregion
#region Bank Deposit - Payment Method * Direct Deposit
                    else if (TransactionMethod == 5)
                    {
                        BankDepositDirectDepositVoucher Obj = new BankDepositDirectDepositVoucher();
                        Obj.Amount = model.Amount;
                        Obj.BankAccountId = model.BankAccountId;
                        Obj.BankLedgerHeadId = model.BankAccountLedgerHeadId;
                        Obj.Notes = model.Notes;
                        Obj.UserID = User.Identity.Name;
                        Obj.LedgerDate = model.LedgerDate;
                        status = new BankDA().InsertBankDepositDirectDepositVoucher(Obj);
                    }

#endregion
                    return RedirectToAction("BankLedger", "Banks", new
                    {
                    @id = model.BankAccountId, @BankName = model.BankNames
                    }

                    );
                }
                catch (Exception ex)
                {
                    return RedirectToAction("BankDeposit", "Banks");
                }
            }
        }

        public ActionResult BankWithdrawal()
        {
            BankWithdrawalViewModel model = new BankWithdrawalViewModel();
            model.BankAccountLedgerHeads = db.BankAccountLedgerHeads.Where(a => a.Editable == true && a.Status == true && a.LedgerTypes == LedgerType.Debit).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BankWithdrawal(BankWithdrawalViewModel model)
        {
            bool status = false;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("BankWithdrawal", "Banks");
            }

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                BankWithdrawalChequeVoucher Obj = new BankWithdrawalChequeVoucher();
                Obj.Amount = model.Amount;
                Obj.Notes = model.Notes;
                Obj.BankAccountId = model.BankAccountId;
                Obj.UserID = User.Identity.Name;
                Obj.BankAccountId = model.BankAccountId;
                Obj.BankLedgerHeadId = model.BankAccountLedgerHeadId;
                Obj.BankId = (int)model.BankNames;
                Obj.LedgerDate = model.LedgerDate;
                status = new BankDA().InsertBankWithdrawalChequeCoucher(Obj);
            }

            return RedirectToAction("BankWithdrawal", "Banks");
        }

        public ActionResult PettyCashWithdrawal()
        {
            BankWithdrawalViewModel model = new BankWithdrawalViewModel();
            model.BankAccountLedgerHeads = db.BankAccountLedgerHeads.Where(a => a.Editable == true && a.Status == true && a.LedgerTypes == LedgerType.Debit).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PettyCashWithdrawal(BankWithdrawalViewModel model)
        {
            bool status = false;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("PettyCashWithdrawal", "Banks");
            }

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                BankWithdrawalChequeVoucher Obj = new BankWithdrawalChequeVoucher();
                Obj.Amount = model.Amount;
                Obj.Notes = model.Notes;
                Obj.BankAccountId = model.BankAccountId;
                Obj.UserID = User.Identity.Name;
                Obj.BankAccountId = model.BankAccountId;
                Obj.BankLedgerHeadId = model.BankAccountLedgerHeadId;
                Obj.BankId = (int)model.BankNames;
                Obj.LedgerDate = model.LedgerDate;
                status = new BankDA().InsertBankWithdrawalForPettyCash(Obj);
            }

            return RedirectToAction("PettyCashWithdrawal", "Banks");
        }

        public PartialViewResult GetBankAccounts(int BankId)
        {
            try
            {
                string sBankId = Convert.ToString(BankId);
                var result = (BankName)Enum.Parse(typeof(BankName), sBankId);
                List<BankAccount> Obj = db.BankAccounts.Where(e => e.BankNames == result).ToList();
                ViewBag.lblClass = "control-label col-md-2";
                ViewBag.inpClass = "col-md-10";
                return PartialView(Obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        public JsonResult GetBankBalance(int AccountId)
        {
            try
            {
                BankAccount Obj = db.BankAccounts.Find(AccountId);
                if (Obj == null)
                {
                    return Json(new
                    {
                    Flag = false, AcNo = "Not Found", AcName = "Not Found", Balance = 0, }

                    );
                }
                else
                {
                    return Json(new
                    {
                    Flag = true, AcNo = Obj.AccountNo, AcName = Obj.AccountNames, Balance = Obj.Balance.ToString("f2"), }

                    );
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                Flag = false, AcNo = "Not Found", AcName = "Not Found", Balance = 0, }

                );
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BankAccount bacc = db.BankAccounts.Find(id);
            if (bacc == null)
            {
                return NotFound();
            }

            return View(bacc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BankAccount bacc)
        {
            if (ModelState.IsValid)
            {
                Int32 AccountId = bacc.Id;
                Int32 BankId = (int)bacc.BankNames;
                String AccountNo = bacc.AccountNo;
                String AccountName = bacc.AccountNames;
                bool status = new BankDA().UpdateBankAccountInformation(AccountId, BankId, AccountNo, AccountName);
                if (status)
                {
                    //FlashMessage.Confirmation("Bank Account Information Updated");
                }
                else
                {
                    //FlashMessage.Danger("Some error occured!!");
                }

                return RedirectToAction("Index");
            }

            return View(bacc);
        }
    }
}