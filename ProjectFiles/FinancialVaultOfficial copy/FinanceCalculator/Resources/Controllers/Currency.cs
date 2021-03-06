// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Collections;

using Foundation;
using UIKit;
using CoreGraphics;

namespace FinanceCalculator
{
	public partial class Currency : UITableViewController
	{
		public Currency (IntPtr handle) : base (handle)
		{
		}

		private List<string> currencyChoice = new List<string>() {
			{"\ud83c\uddfa\ud83c\uddf8 US Dollar (USD)"},{"\ud83c\uddea\ud83c\uddfa European Euro (EUR)"},{"\ud83c\uddef\ud83c\uddf5 Japanese Yen (JPY)"},
			{"\ud83c\uddec\ud83c\udde7 British Pound (GBP)"}, {"\ud83c\udde8\ud83c\udded Swiss Franc (CHF)"},{"\ud83c\udde8\ud83c\udde6 Canadian Dollar (CAD)"},{"\ud83c\udde6\ud83c\uddfa Australian Dollar (AUD)"},{"\ud83c\uddff\ud83c\udde6 South African Rand (ZAR)"}, {"\ud83c\uddf3\ud83c\uddff New Zealand Dollar (NZD)"},
			{"\ud83c\uddf2\ud83c\uddfd Mexican Peso (MXN)"},{"\ud83c\udde8\ud83c\uddf3 Chinese Yuan (CNY)"},{"\ud83c\uddf8\ud83c\uddea Swedish Krona (SEK)"},
			{"\ud83c\uddf7\ud83c\uddfa Russian Ruble (RUB)"},{"\ud83c\udded\ud83c\uddf0 Hong Kong Dollar (HKD)"},{"\ud83c\uddf3\ud83c\uddf4 Norwegian Krone (NOK)"},{"\ud83c\uddf8\ud83c\uddec Singapore Dollar (SGD)"}, {"\ud83c\uddf9\ud83c\uddf7 Turkish Lira (TRY)"},
			{"\ud83c\uddf0\ud83c\uddf7 South Korean Won(KRW)"},{"\ud83c\udde7\ud83c\uddf7 Brazilian Real (BRL)"},{"\ud83c\uddee\ud83c\uddf3 Indian Rupee (INR)"}
		};

		private List<string> currencySymbol = new List<string>()
		{
			{"$"},{"€"},{"¥"},{"£"},{"Fr"},{"$"},{"$"}, {"R"},{"$"},{"$"},
			{"¥"},{"kr"},{"₽"},{"$"},{"kr"},{"$"},{"₺"},{"₩"},
			{"R$"},{"₹"}
		};



		public double incomeTotal;
		public double expensesTotal;

		//expenses total items
		public double rentRef;
		public double housingRef;
		public double mortgageRef;
		public double insuranceRef;
		public double taxesRef;
		public double carPaymentsRef;
		public double educationRef;
		public double electronicsRef;
		public double entertainmentRef;
		public double clothingRef;
		public double petsRef;
		public double charityRef;
		public double foodRef;
		public double healthLifestyleRef;
		public double gardeningRef;
		public double cleaningRef;
		public double utilitiesRef;
		public double otherExpenseRef;



		//income total items
		public double wagesRef;
		public double realestateRef;
		public double salesHouseStockRef;
		public double smallBusinessRef;
		public double gamblingWinningsRef;
		public double salesOfTradesRef;
		public double intellectualPropertyRef;
		public double appRoyaltiesRef;
		public double bookPublishingRef;
		public double tradeDividendsRef;
		public double bankInterestRef;
		public double taxReturnRef;
		public double studentLoanRef;
		public double inheritanceRef;
		public double prizeMoneyRef;
		public double otherIncomeRef;

		public string symbolCurrencyHandler;  //currency symbol used

		public List<double> expensesValues = new List<double>()
		{
		};
		public List<double> incomeValues = new List<double>() { };

		// values
		public Currency(double incomeRef, double expensesRef, double rent,
										 double housing, double mortgage, double insurance, double taxes, double carPayments, double education, double electronics,
										 double entertainment, double clothing, double pets, double charity, double food, double healthLifestyle, double gardening,
										 double cleaning, double utilities, double otherExpense,
										 double wages, double realestate, double salesHouseStock, double smallBusiness, double gamblingWinnings, double salesOfTrades, double intellectualProperty, double appRoyalties, double bookPublishing, double tradeDividends,
										  double bankInterest, double taxReturn, double studentLoan, double inheritance, double prizeMoney, double otherIncome, string symbol)
		{
			//total 
			incomeTotal = incomeRef;
			expensesTotal = expensesRef;

			symbolCurrencyHandler = symbol;

			//expenses values
			rentRef = rent;
			housingRef = housing;
			mortgageRef = mortgage;
			insuranceRef = insurance;
			taxesRef = taxes;
			carPaymentsRef = carPayments;
			educationRef = education;
			electronicsRef = electronics;
			entertainmentRef = entertainment;
			clothingRef = clothing;
			petsRef = pets;
			charityRef = charity;
			foodRef = food;
			healthLifestyleRef = healthLifestyle;
			gardeningRef = gardening;
			cleaningRef = cleaning;
			utilitiesRef = utilities;
			otherExpenseRef = otherExpense;

			//income values
			wagesRef = wages;
			realestateRef = realestate;
			salesHouseStockRef = salesHouseStock;
			smallBusinessRef = smallBusiness;
			gamblingWinningsRef = gamblingWinnings;
			salesOfTradesRef = salesOfTrades;
			intellectualPropertyRef = intellectualProperty;
			appRoyaltiesRef = appRoyalties;
			bookPublishingRef = bookPublishing;
			tradeDividendsRef = tradeDividends;
			bankInterestRef = bankInterest;
			taxReturnRef = taxReturn;
			studentLoanRef = studentLoan;
			inheritanceRef = inheritance;
			prizeMoneyRef = prizeMoney;
			otherIncomeRef = otherIncome;

			expensesValues = new List<double>() {
				rentRef,housingRef,mortgageRef,insuranceRef,taxesRef,carPaymentsRef,educationRef,electronicsRef,entertainmentRef,clothingRef,petsRef,charityRef,foodRef,
				healthLifestyleRef,gardeningRef,cleaningRef,utilitiesRef,otherExpenseRef
			};
			incomeValues = new List<double>() {
			 wagesRef, realestateRef,salesHouseStockRef,smallBusinessRef,gamblingWinningsRef,salesOfTradesRef,intellectualPropertyRef,appRoyaltiesRef,
			bookPublishingRef,tradeDividendsRef,bankInterestRef,taxReturnRef,studentLoanRef,inheritanceRef,prizeMoneyRef,otherIncomeRef
			};
		}



		private void alertInstructions(string title, string message)
		{
			UIAlertController instructionsController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

			UIAlertAction confirmed = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (Action) =>
			{
				instructionsController.Dispose();
			});

			instructionsController.AddAction(confirmed);

			if (this.PresentedViewController == null)
			{
				this.PresentViewController(instructionsController, true, null);
			}

			else if (this.PresentedViewController != null)
			{
				this.PresentedViewController.DismissViewController(true, () =>
				{
					this.PresentedViewController.Dispose();
					this.PresentViewController(instructionsController, true, null);
				});
			}
		}

		List<string> category = new List<string>() { };
		List<double> expenses = new List<double>() { };
		List<string> name = new List<string>() { };

		public Currency() { }
		public Currency(List<string> categoryRef, List<double> expensesRef, List<string> nameRef) {
			category = categoryRef;
			expenses = expensesRef;
			name = nameRef; 
		}

		public override void ViewDidAppear(bool animated)
		{
			this.NavigationController.SetNavigationBarHidden(false, true);

			this.NavigationController.ToolbarHidden = false;
		}

		public override void Transition(UIViewController fromViewController, UIViewController toViewController, double duration, UIViewAnimationOptions options, Action animations, UICompletionHandler completionHandler)
		{
			TotalCalculationController totalTrans = this.Storyboard.InstantiateViewController("TotalCalculationController") as TotalCalculationController; 
			if(fromViewController == totalTrans) {
				alertInstructions("Vault Updated!", "Your vault has been updated with your income and expenses. You can view your vault at any time and you can now start another manual entry of your financials.");
			} 
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			alertInstructions("Welcome to the Budget Calculator", "Choose the currency you want to calculate your financials with and we'll get started");
			this.NavigationItem.Title = "Choose a currency";
		}


		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell currencyCell = tableView.DequeueReusableCell("currencyCell");

			if (currencyCell == null)
			{
				currencyCell = new UITableViewCell(UITableViewCellStyle.Value1, "currencyCell");
			}
				
			currencyCell.TextLabel.Text = currencyChoice[indexPath.Row];
			currencyCell.TextLabel.TextColor = UIColor.Black;


			UITextField currencySymbolText = new UITextField();

			currencySymbolText.Frame = new CoreGraphics.CGRect(0, 0, 60, 30);

			currencySymbolText.UserInteractionEnabled = false;
			currencySymbolText.BorderStyle = UITextBorderStyle.None;
			currencySymbolText.Font = UIFont.BoldSystemFontOfSize(18.0f);
			currencySymbolText.Text = this.currencySymbol[indexPath.Row];

			currencyCell.AccessoryView = currencySymbolText;

			return currencyCell;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return this.currencyChoice.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			
			ExpenseController expController = new ExpenseController();
			switch (indexPath.Row)
			{
				case 0:
					expController = new ExpenseController(this.currencySymbol[0]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 1:
					expController = new ExpenseController(this.currencySymbol[1]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 2:
					expController = new ExpenseController(this.currencySymbol[2]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 3:
					expController = new ExpenseController(this.currencySymbol[3]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 4:
					expController = new ExpenseController(this.currencySymbol[4]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 5:
					expController = new ExpenseController(this.currencySymbol[5]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 6:
					expController = new ExpenseController(this.currencySymbol[6]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 7:
					expController = new ExpenseController(this.currencySymbol[7]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 8:
					expController = new ExpenseController(this.currencySymbol[8]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 9:
					expController = new ExpenseController(this.currencySymbol[9]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 10:
					expController = new ExpenseController(this.currencySymbol[10]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 11:
					expController = new ExpenseController(this.currencySymbol[11]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 12:
					expController = new ExpenseController(this.currencySymbol[12]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 13:
					expController = new ExpenseController(this.currencySymbol[13]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 14:
					expController = new ExpenseController(this.currencySymbol[14]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 15:
					expController = new ExpenseController(this.currencySymbol[15]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 16:
					expController = new ExpenseController(this.currencySymbol[16]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 17:
					expController = new ExpenseController(this.currencySymbol[17]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 18:
					expController = new ExpenseController(this.currencySymbol[18]);
					this.NavigationController.PushViewController(expController, true);

					break;

				case 19:
					expController = new ExpenseController(this.currencySymbol[19]);
					this.NavigationController.PushViewController(expController, true);

					break;

				default:
					expController = new ExpenseController(this.currencySymbol[20]);
					this.NavigationController.PushViewController(expController, true);

					break;
			}
			tableView.DeselectRow(indexPath, true);
		}
	}
}
