using UnityEngine;
using System.Collections;
using System;
using System.Net; 
using System.Net.Mail; 
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;

public class SendAllFilesEmail : MonoBehaviour {

	private static string status;
	public GameObject theDebugLabel;
	private static Boolean outputDebug = false;

	public GameObject subjectLabel;
	public GameObject toLabel;

	private GameObject GameEngine;


	// Use this for initialization
	void Start () {
		GameEngine = GameObject.Find("GameEngine");
	}

	void Update()
	{
		if(outputDebug)
		{
			theDebugLabel.GetComponent<UILabel>().text = status;
			if(status.Substring(0,11) == "Email Error" )
			{
				outputDebug = false;
			}
			if(status == "Message Sent")
			{
				outputDebug = false;
			}
			if(status == "No Internet Connection")
			{
				outputDebug = false;
			}
		}
	}

	void OnClick()
	{
		outputDebug = true;
		send_email_with_attachment();
	}
	
	bool InternetConnection()
	{
		try
		{
			using (var client = new WebClient())
				using (var stream = client.OpenRead("http://www.google.com"))
			{
				return true;
			}
		}
		catch
		{
			return false;
		}
		return false;
	}
	
	private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e) //private static void
	{
		// Get the unique identifier for this asynchronous operation.
		String token = (string) e.UserState;
		
		if (e.Cancelled)
		{
			//Debug.Log("[{0}] Send canceled."+token);
			//status = "Email Not Sent!";
		}
		if (e.Error != null)
		{
			status = "Email Error: " + e.Error.Message.ToString();
			//Debug.Log("[{0}] {1}"+token+e.Error.ToString());
		} else
		{
			status = "Message Sent";
			//Debug.Log("Message sent.");
		}
		//outputDebug = false;
	}



	void send_email_with_attachment()
	{
		
		if(InternetConnection())
		{
			//status = "There is internet Connection!";
			//Debug.Log(status);
			
			MailMessage mail = new MailMessage();
			mail.From = new MailAddress("ucr.bgc.spatialrelease@gmail.com");
			mail.To.Add(toLabel.GetComponent<UILabel>().text);
			mail.Subject = subjectLabel.GetComponent<UILabel>().text;
			mail.Body = "Spatial Release Application Email.";
			
			//Add the .txt file as an attachment
			//mail.Attachments.Add (new System.Net.Mail.Attachment(Application.persistentDataPath + "/" + "ConversionFiles" + "/" + "default.txt"));


			/**************************** ATTACH ALL FILES********************************/

			DirectoryInfo dirTemp = new DirectoryInfo(Application.persistentDataPath);
			DirectoryInfo[] dirs = dirTemp.GetDirectories();
			//DirectoryInfo[] files = dirTemp.get
			
			if(dirs.Length > 0)
			{
				for(int i =0; i < dirs.Length;i++)
				{	
					//Debug.Log(dirs[i].Name);
					if(dirs[i].Name[0] == 'S')
					{
						//For every session folder get all of its files and attach
						FileInfo[] files = dirs[i].GetFiles();
						if(files.Length > 0)
						{
							for(int j =0; j < files.Length;j++)
							{	
								//Debug.Log(files[j].Name);
								mail.Attachments.Add (new System.Net.Mail.Attachment(files[j].FullName));

							}
						}
						//Done with files

					}
				}
				

			}

			/**************************** END ATTACH ALL FILES****************************/




			
			//SMTP Stuff
			SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
			smtpServer.Port = 587;
			smtpServer.Credentials = new System.Net.NetworkCredential("ucr.bgc.spatialrelease@gmail.com", "BrainRelease364") as ICredentialsByHost;
			smtpServer.EnableSsl = true;
			
			//I dont know why this is used for... Apparently I need it for sending the message or else you get an error about
			//System.IO.IOException: The authentication or decryption has failed.
			
			ServicePointManager.ServerCertificateValidationCallback = 
				delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
			{ return true; };
			
			// Set the method that is called back when the send operation ends.
			smtpServer.SendCompleted += new 
				SendCompletedEventHandler(SendCompletedCallback);
			string userState = "message";
			smtpServer.SendAsync(mail, userState);
			status = "Sending Email";
			//Debug.Log (status);
			// Clean up.
			mail.Dispose();
			
			
		}
		else
		{
			status = "No Internet Connection";
			//Debug.Log(status);
			//Possibly Show Message saying "Could not send email because there is not Internet Connection"
			//Connect to IExplorer to get Files
		}
		
	}




}
