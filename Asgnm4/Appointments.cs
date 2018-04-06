using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Asgnm4
{
    class Appointments
    {
        public static int MAX_CLIENTS = 9;
        public List<ICustomer> clientsList=null;
        public Appointments()
        {
            clientsList = new List<ICustomer>();
        }
        public ICustomer this[int i]
        {
            get { return clientsList[i]; }
            set {clientsList[i] = value; }
        }
        public void Add(ICustomer customer)
        { 
            clientsList.Add(customer);
        }
        /*public void CreateSchedule()
        {
            for (int clientNumber = 0; clientNumber < MAX_CLIENTS; clientNumber++)
            {

                if (!InsertHouseType())
                    break;
                NameInsert(clientNumber);
                TimeInsert(clientNumber);
                AgeInsert(clientNumber);
                SizeInsert(clientNumber);
                PaddockSizeInsert(clientNumber);
                clientsList.Sort();
            } 
        }*/
        public void AddClientWPF(int clientNumber,int houseType,string name, int time,uint age,double size,double paddockSize)
        {
            InsertHouseTypeWPF(clientNumber,houseType);
            NameInsertWPF(clientNumber,name);
            TimeInsertWPF(clientNumber,time);
            AgeInsertWPF(clientNumber,age);
            SizeInsertWPF(clientNumber,size);
            PaddockSizeInsertWPF(clientNumber,paddockSize);
            clientsList.Sort();
        }
        public void StartDay()
        {
            if(clientsList.Count()==0)
                Console.WriteLine("No clients for today");
            for(int i=0;i<clientsList.Count();i++)
            {
                Console.WriteLine("{0}:00 {1}",clientsList[i].Time,clientsList[i].Name);
                clientsList[i].CreateDesign();
                clientsList[i].EstimateWork();
                clientsList[i].ArrangeWorkers();
            }
        }
        private void InsertHouseTypeWPF(int clientNumber, int houseType)
        {
            Customer customer = null;
            switch(houseType)
            {
                case 0:
                    customer = new House();
                    break;
                case 1:
                    customer = new Farmer();
                    break;
                case 2:
                    customer = new Business();
                    break;
                default:
                    break;
            }
            Add(customer);
        }
        /*private bool InsertHouseType()
        {
            Customer customer = null;
            string tempAnswer = null;
            do
            {
                Console.Write("Please, insert '1' if you are a business owner, '2' if you own a regular house, '3' if you own a farmhouse or 'q' to quit: ");
                tempAnswer = Console.ReadLine();
                int tempHouseType = 0;
                if (tempAnswer == "q")
                {
                    tempAnswer = "quit";
                    break;
                }
                else if (tempAnswer.Count() == 1 && int.TryParse(tempAnswer, out tempHouseType))
                {
                    switch (tempHouseType)
                    {
                        case 1:
                            customer = new Business();
                            break;
                        case 2:
                            customer = new House();
                            break;
                        case 3:
                            customer = new Farmer();
                            break;
                        default:
                            break;
                    }
                }
            } while (customer == null);
            if (tempAnswer == "quit")
                return false;
            Add(customer);
            return true;
        }*/
        private void NameInsertWPF(int clientNumber,string name)
        {
            clientsList[clientNumber].Name = name;
        }
        /*private void NameInsert(int clientNumber)
        {
            string tempAnswer = null;                                                                  
            do
            {
                Console.Write("Please, insert your name: ");
                tempAnswer = Console.ReadLine();
            } while (tempAnswer.Count() == 0);
            clientsList[clientNumber].Name = tempAnswer;
        }*/
        private void TimeInsertWPF(int clientNumber,int time)
        {
            clientsList[clientNumber].Time = time;
        }
        /*private void TimeInsert(int clientNumber)
        {
            do
            {
                if (clientsList.Count() == 1)
                    Console.Write("Please select any time from 9:00 to 17:00 and insert at what hour you would like to come (for example, insert '9' if you want to come at 09:00): ");
                else
                {
                    Console.Write("There are appointments at: ");
                    for (int i = 0; i < clientsList.Count() - 1; i++)
                    {
                        Console.Write("{0}:00 ", clientsList[i].Time);
                    }
                    Console.WriteLine("");
                    Console.Write("Please select any other solid time from 9:00 to 17:00 and insert at what hour you would like to come (for example, insert '9' if you want to come at 09:00): ");
                }
                string tempTime = Console.ReadLine();
                if (tempTime.Length == 2 || tempTime.Length == 1)
                {
                    int tempIntTime;
                    if(int.TryParse(tempTime,out tempIntTime))
                    {
                        if (tempIntTime >= 9 && tempIntTime <= 17)
                        {
                            bool isTimeNotBusy = true;
                            for(int i=0;i<clientsList.Count()-1;i++)
                            {
                                if (clientsList[i].Time == tempIntTime)
                                {
                                    isTimeNotBusy = false;
                                    break;
                                }
                            }
                            if (isTimeNotBusy)
                            {
                                clientsList[clientNumber].Time = tempIntTime;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("This time is busy");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong input");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            } while (true);

        }*/
        private void AgeInsertWPF(int clientNumber,uint age)
        {
            clientsList[clientNumber].Age = age;
        }
        /*private void AgeInsert(int clientNumber)
        {
            string tempAgeString = null;                                                             
            uint tempAge = 0;
            do
            {
                Console.Write("How old is your house (in years)? ");
                tempAgeString = Console.ReadLine();
            } while (tempAgeString == string.Empty || !uint.TryParse(tempAgeString, out tempAge));
            clientsList[clientNumber].Age = tempAge;
        }*/
        private void SizeInsertWPF(int clientNumber,double size)
        {
            clientsList[clientNumber].Size = size;
        }
        /*private void SizeInsert(int clientNumber)
        {
            string tempSizeString = null;                                                          //size insert
            double tempSize = 0;
            do
            {
                Console.Write("Insert your building size in square feets: ");
                tempSizeString = Console.ReadLine();
            } while (tempSizeString == string.Empty || !double.TryParse(tempSizeString, out tempSize) || tempSize <= 0);
            clientsList[clientNumber].Size = tempSize;
        }*/
        private void PaddockSizeInsertWPF(int clientNumber,double paddockSize)
        {
            clientsList[clientNumber].PaddockSize = paddockSize;
        }
        /*private void PaddockSizeInsert(int clientNumber)
        {
            string tempPaddockSizeString = null;                                                   // paddock size insert
            double tempPaddockSize = 0;
            do
            {
                Console.Write("Insert your paddock size in square feets: ");
                tempPaddockSizeString = Console.ReadLine();
            } while (tempPaddockSizeString == string.Empty || !double.TryParse(tempPaddockSizeString, out tempPaddockSize) || tempPaddockSize < 0);
            clientsList[clientNumber].Size = tempPaddockSize;
        }*/
        public void WriteIntoBinaryFile(int clientNumber)
        {
            FileStream fs = null;
            fs = new FileStream("Appointments.txt", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < clientNumber; ++i)
            {
                string time = "";
                time += clientsList[i].Time.ToString();
                time += ":00";
                bw.Write(time);
                if (clientsList[i].GetType() == typeof(House))
                {
                    bw.Write("Regular house");
                }
                else if (clientsList[i].GetType() == typeof(Farmer))
                {
                    bw.Write("Farm");
                }
                else if (clientsList[i].GetType() == typeof(Business))
                {
                    bw.Write("Business centre");
                }
                bw.Write(clientsList[i].Name);
                bw.Write(clientsList[i].Age);
                bw.Write(clientsList[i].Size);
                bw.Write(clientsList[i].PaddockSize);
            }
            bw.Close();
            fs.Close();
            
        }
        public int ReadXMLFile()
        {
            clientsList = new List<ICustomer>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            if (!File.Exists("schedule.xml"))
            {
                XmlWriterSettings settingsWr = new XmlWriterSettings();
                settingsWr.Indent = true;
                settingsWr.IndentChars = "\t";
                XmlWriter writer = XmlWriter.Create("schedule.xml", settingsWr);
                writer.WriteStartDocument();
                writer.WriteStartElement("Clients");
                writer.WriteEndElement();
                writer.Close();
            }
            XmlReader reader = XmlReader.Create("schedule.xml", settings);
            int count = 0;
            if (reader.ReadToDescendant("Client"))
            {
                do
                {
                    reader.ReadStartElement();
                    Customer c=null;
                    string tempType = reader.ReadElementContentAsString();
                    if (tempType.Equals("Regular house"))
                        c = new House();
                    else if (tempType.Equals("Business centre"))
                        c = new Business();
                    else if (tempType.Equals("Farm"))
                        c = new Farmer();
                    string tempTime = reader.ReadElementContentAsString();
                    string tempTime2="";
                    tempTime2 += tempTime[0];
                    if (tempTime[0] != '9')
                        tempTime2 += tempTime[1];
                    
                    c.Time =Int32.Parse(tempTime2);
                    c.Name= reader.ReadElementContentAsString();
                    c.Age= (uint)reader.ReadElementContentAsInt();
                    c.Size= reader.ReadElementContentAsDouble();
                    c.PaddockSize = reader.ReadElementContentAsDouble();
                    clientsList.Add(c);
                    count++;
                } while (reader.ReadToNextSibling("Client"));
            }
            reader.Close();
            return count;
        }
        public void WriteIntoXML(int clientNumber)
        {
            XmlWriterSettings settings= new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            
            XmlWriter writer = XmlWriter.Create("schedule.xml", settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Clients");
            foreach (Customer c in clientsList)
            {
                writer.WriteStartElement("Client");
                string tempType = "unknown";
                if (c.GetType() == typeof(House))
                {
                    tempType = "Regular house";
                }
                else if (c.GetType() == typeof(Business))
                {
                    tempType = "Business centre";
                }
                else if (c.GetType() == typeof(Farmer))
                {
                    tempType = "Farm";
                }
                writer.WriteElementString("type", tempType);
                string tempTime = c.Time.ToString() + ":00";
                writer.WriteElementString("time", (tempTime));
                writer.WriteElementString("name", c.Name);
                writer.WriteElementString("age", c.Age.ToString());
                writer.WriteElementString("size", c.Size.ToString());
                writer.WriteElementString("paddockSize", c.PaddockSize.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
        }
        public string ReadBinaryFile(int clientNumber)
        {
            FileStream fs = null;
            fs = new FileStream("Appointments.txt", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            string str = "";
            for (int i = 0; i < clientNumber; ++i)
            {
                str += "Time: ";
                str += br.ReadString();
                str += "  Type: ";
                str += br.ReadString();
                str += "  Client's name: ";
                str += br.ReadString();
                str += "  House age: ";
                str += br.ReadUInt32();
                str += "  House size: ";
                str += br.ReadDouble();
                str += "  Paddock size: ";
                str += br.ReadDouble();
                str += "\n";
            }
            br.Close();
            fs.Close();
            return str;
        }
    }
}
