using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class FileManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//For TimeStamp!
		//Debug.Log (DateTime.Now.Second);

		//Create DB Conversion Directory 
		DirectoryInfo dirConvFiles = new DirectoryInfo(Application.persistentDataPath + "/" + "ConversionFiles");

		if(!dirConvFiles.Exists)
		{ 
			//Debug.Log ("Creating ConversionFiles");
			dirConvFiles.Create(); 
		}

		//Create DB conversion default file if it doesnt exist!
		StreamWriter fileWriter = null;
		string defaultConvFile = Application.persistentDataPath + "/" + "ConversionFiles" + "/" + "default.txt";
		FileInfo defaultConvFileInfo = new FileInfo(Application.persistentDataPath + "/" + "ConversionFiles" + "/" + "default.txt");

		if(!defaultConvFileInfo.Exists)
		{
			fileWriter = File.CreateText(defaultConvFile);
			
			for(int i = 0; i < 100; i++)
			{
				fileWriter.WriteLine((i+1) + " .01");
			}
			fileWriter.Close();
			//Debug.Log ("Created Conversion Default File");
		}
		else
		{
			//Debug.Log("Conversion Default File Already Exists");
		}



		/*   A Way to read contents of a directory!
		//Read Contents of ConversionFiles folder
		DirectoryInfo dirTemp = new DirectoryInfo(Application.persistentDataPath + "/" + "ConversionFiles");
		FileInfo[] files = dirTemp.GetFiles();

		if(files.Length > 0)
		{
			for(int i =0; i < files.Length;i++)
			{	
				Debug.Log(files[i].Name);
			}
		}*/

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
