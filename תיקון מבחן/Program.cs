using System.Diagnostics;

namespace תיקון_מבחן
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}
		static Node<Call> Generate(Node<Call> calls, int thereshold)//תיקון שאלה 1
		{
			Node<Call> current = calls;//מצביע
			Node<Call> newcalls = new Node<Call>(null);
			Node<Call> last = newcalls;//מצביע
			while (current != null)
			{
				if (current.GetValue().Getseconds() > thereshold || current.GetValue().Getcustomer().Getyears() > 5)
				{
					last.SetNext(new Node<Call>(new Call(current.GetValue().Getcustomer(), current.GetValue().Getseconds())));
					last = last.GetNext();
				}
				current = current.GetNext();
			}
			return newcalls.GetNext();
		}
	}
	public class Customer
	{
		private string name;
		private int yearAsmember;
		public Customer(string name, int yearAsmember)
		{
			this.name = name;
			this.yearAsmember = yearAsmember;
		}
		public int Getyears()
		{
			return yearAsmember;
		}
	}
	public class Call
	{
		private Customer customer;
		private int seconds;
		public Call(Customer customer, int seconds)
		{
			this.customer = customer;
			this.seconds = seconds;
		}

		public int Getseconds()
		{
			return seconds;
		}
		public Customer Getcustomer()
		{
			return customer;
		}
	}
	public class CallCenter()
	{
		private Node<Call> CallList;

		public Customer MaxVIPwait()//שאלה 1
		{
			Node<Call>  current = CallList;
			int max = int.MinValue;
			Customer VIP = null;
			while (current != null)
			{
				if(current.GetValue().Getcustomer().Getyears() > 5 && current.GetValue().Getseconds() > max)
				{
					max = current.GetValue().Getseconds();
					VIP = current.GetValue().Getcustomer();
				}
				current = current.GetNext();
			}
			return VIP;
		}
	}
	public class Date
	{
		private int day;
		private int month;
		private int year;

		public Date(int day, int month, int year)
		{
			this.day = day;
			this.month = month;
			this.year = year;
		}
	}
	public class Event
	{
		protected Date date;
		protected int hour;

		public Event(Date date, int hour)
		{
			this.date = date;
			this.hour = hour;
		}
		public Event(Event other)
		{
			this.date = other.date;
			this.hour = other.hour;
		}

		public Date Getdate()
		{
			return date;
		}

		public virtual bool Match(string name)
		{
			return false;
		}
	}
	public class Meeting : Event
	{
		private string[] arrNames;
		private int duration;
		private string location;

		public Meeting(Date date, int hour, string[] arrNames, int duration, string location)
			: base(date, hour)
		{
			this.arrNames = arrNames;
			this.duration = duration;
			this.location = location;
		}
		public override bool Match(string name)
		{
			for (int i = 0; i < arrNames.Length; i++)
			{
				{
					if (arrNames[i] == name)
						return true;
				}
			}
			return false;
		}
	}

		// מחלקת PhoneCall
	public class PhoneCall :Event
	{
		private string phoneNumber;
		private string name;

		public PhoneCall(Date date, int hour, string phoneNumber, string name)
			: base(date, hour)
		{
			this.phoneNumber = phoneNumber;
			this.name = name;
		}
		public override bool Match(string name)
		{
			return (this.name == name);
		}
	}

	// מחלקת Task
	public class Task : Event
	{
		private string title;

		public Task(Date date, int hour, string title)
			: base(date, hour)
		{
			this.title = title;
		}
	}

	// מחלקת Diary
	public class Diary
	{
		private Node<Event> events; 

		public Diary(Node<Event> events)
		{
			this.events = events;
		}

		public PhoneCall[] AllCalls(Date date)
		{
			PhoneCall[] arr = new PhoneCall[100];
			int index = 0;
			foreach(Event e in arr)
			{
				if(e is PhoneCall)
				{
					if(e.Getdate().Same(date))
					{
						if(e is PhoneCall)
						{
							arr[index] = (PhoneCall)e;
							index++;
						}
					}
				}
			}
			return arr;
		}
	}
}
