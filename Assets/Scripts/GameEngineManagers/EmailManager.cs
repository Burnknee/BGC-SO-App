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

public class EmailManager : MonoBehaviour {

	private int count = 0;
	//public GameObject EmailLabel;
	public GameObject titleLabel;
	private static string status = "Email";

	//private List<GameObject> folders = new List<GameObject>();
	public GameObject theGridParent;
	public GameObject theFileGridParent;
	public GameObject currentFolder = null;
	public GameObject to_Label;
	public GameObject subject_Label;
	public GameObject numofFilesLabel;
	public GameObject debugStatusLabel;

	public GameObject cancelBtn;

	public void FileClicked(GameObject the_file)
	{
		//Debug.Log(the_file.GetComponent<FileItem>().nameOfFile);



	}


	public void reset()
	{
		if(currentFolder != null)
		{
			currentFolder.GetComponent<FolderItem>().itsBG.SetActive(false);
		}

		//Reset To: Label and Default Subject
		to_Label.GetComponent<UILabel>().text = "";
		subject_Label.GetComponent<UILabel>().text = "";
		debugStatusLabel.GetComponent<UILabel>().text = "";

		//Destroy the children of theGrid
		GameObject temp;
		for(int i =0; i < theGridParent.transform.childCount; i++)
		{
			GameObject.Destroy(theGridParent.transform.GetChild(i).gameObject);
		}


	}

	public void FolderClicked(GameObject the_folder)
	{
		if(the_folder != currentFolder)
		{
			the_folder.GetComponent<FolderItem>().itsBG.SetActive(true);

			//Destroy all files and reposition the grid.
			//Destroy the children of theFileGrid
			if(theFileGridParent.transform.childCount != 0)
			{
				for(int i =0; i < theFileGridParent.transform.childCount; i++)
				{
					GameObject.Destroy(theFileGridParent.transform.GetChild(i).gameObject);
				}
			}
			//Add new Children


			//Read Contents each Folder
			DirectoryInfo dirTemp = new DirectoryInfo(Application.persistentDataPath+"/"+the_folder.GetComponent<FolderItem>().nameOfFolder);
			FileInfo[] files = dirTemp.GetFiles();
			if(files.Length > 0)
			{
				for(int i =0; i < files.Length;i++)
				{	
					GameObject a_file = Instantiate(Resources.Load("FileItem")) as GameObject;
					a_file.transform.parent = theFileGridParent.transform;
					Vector3 newPos = new Vector3(0,0,0);
					a_file.transform.localPosition = newPos;
					newPos.x = 1;
					newPos.y = 1;
					newPos.z = 1;
					a_file.transform.localScale = newPos;
					a_file.GetComponentInChildren<UILabel>().text = files[i].Name;
					a_file.GetComponent<FileItem>().nameOfFile = files[i].Name;
				}
				
				theFileGridParent.GetComponent<UIGrid>().Reposition();
			}
			//Done with files





		}
		if(currentFolder != null)
		{

			if(the_folder != currentFolder)
			{
				currentFolder.GetComponent<FolderItem>().itsBG.SetActive(false);
			}
		}
		currentFolder = the_folder;
		//Debug.Log (the_folder.GetComponent<FolderItem>().nameOfFolder);
		     


	}

	public void updateNumOfFiles()
	{
		int count= 0;
		
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
							count++;
							
						}
					}
					//Done with files
					
				}
			}
			
			
		}
		
		numofFilesLabel.GetComponent<UILabel>().text = "* "+count.ToString()+" files";
	}
	public void ShowEmailScreen(int location) //0: from settings 1: from end session
	{
		titleLabel.GetComponent<UILabel>().text = "Email";

		if(location == 0)
		{
			//Debug.Log ("From Settings");
			cancelBtn.GetComponent<CancelButtonEmailScreen>().whoCalled = 0;
			//Change Cancel Buttons Animations
			UIButtonPlayAnimation[] cancelAnims;
			cancelAnims = cancelBtn.GetComponents<UIButtonPlayAnimation>();
			
			for(int i = 0; i < cancelAnims.Length ; i++)
			{
				if((i == 1) || (i == 2) || (i == 0))
				{
					cancelAnims[i].enabled = true;
				}
				else{
					cancelAnims[i].enabled = false;
				}

			}
		}
		else if(location == 1)
		{
			//Debug.Log("From End Session Btn");
			cancelBtn.GetComponent<CancelButtonEmailScreen>().whoCalled = 1;

			//Change Cancel Buttons Animations
			UIButtonPlayAnimation[] cancelAnims;
			cancelAnims = cancelBtn.GetComponents<UIButtonPlayAnimation>();
			
			for(int i = 0; i < cancelAnims.Length ; i++)
			{
				if((i == 1) || (i == 2))
				{
					cancelAnims[i].enabled = false;
				}
				else{
					cancelAnims[i].enabled = true;
				}
				
			}
		}

		//Populate the folders in attachments 
		//Uncomment for more control!
	/*
		//Read Contents of ConversionFiles folder
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

					GameObject folder = Instantiate(Resources.Load("FolderItem")) as GameObject;
					folder.transform.parent = theGridParent.transform;
					Vector3 newPos = new Vector3(0,0,0);
					folder.transform.localPosition = newPos;
					newPos.x = 1;
					newPos.y = 1;
					newPos.z = 1;
					folder.transform.localScale = newPos;
					folder.GetComponentInChildren<UILabel>().text = dirs[i].Name.Substring(8);
					folder.GetComponent<FolderItem>().nameOfFolder = dirs[i].Name;
				}
			}

			theGridParent.GetComponent<UIGrid>().Reposition();
		}*/
	}
	
	void OnClick()
	{
		//send_email_with_attachment();
	}
	
	void Update()
	{
		//EmailLabel.GetComponent<UILabel>().text = status;
		//Debug.Log (status);
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
			status = "Email Not Sent!";
		}
		if (e.Error != null)
		{
			status = "Email Not Sent";
			//Debug.Log("[{0}] {1}"+token+e.Error.ToString());
		} else
		{
			status = "Email Sent";
			//Debug.Log("Message sent.");
		}
	}
	
	void send_email_with_attachment()
	{
		
		if(InternetConnection())
		{
			status = "There is internet Connection!";
			
			MailMessage mail = new MailMessage();
			mail.From = new MailAddress("ucr.bgc.spatialrelease@gmail.com");
			mail.To.Add("brami010@student.ucr.edu");
			mail.Subject = "Test Mail";
			mail.Body = "This is for testing SMTP mail from Spatial Release Mail!";
			
			//Add the .txt file as an attachment
			mail.Attachments.Add (new System.Net.Mail.Attachment(Application.persistentDataPath + "/" + "ConversionFiles" + "/" + "default.txt"));
			
			
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
			// Clean up.
			mail.Dispose();
			
			
		}
		else
		{
			status = "No Internet Connection";
			//Possibly Show Message saying "Could not send email because there is not Internet Connection"
			//Connect to IExplorer to get Files
		}
		
	}
}
