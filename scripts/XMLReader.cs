using UnityEngine;
using System.Collections;
using System.Xml;

public class XMLReader : MonoBehaviour {

	/*
	Create a xml file with name thats matching with filename string in your unity project /assets/resources folder
	Structure will look like:
	<!--
	<?xml version="1.0" encoding="utf-8"?>
	<examples>
		<example>
			<id>1</id>
			<name>Example1</name>
		</example>
		<example>
			<id>2</id>
			<name>Example2</name>
		</example>
	</examples>
	-->
	Its possible to add and modify nodes, but you need to add/change them in this script aswell.
	*/
	
	private string filename = "exampleXML"; //xml filename in resources folder
	private Example[] examples;
		
	class Example{
		public int id; //matching the node in xml
		public string name; //matching the node in xml
		
		public Example(int id, string name){
			this.id = id;
			this.name = name;
		}
	}
	
	void Start () {
		GetExamples(filename);
		
		Debug.Log(examples[0].name); //Debug name of first example node
	}
	
	public void GetExamples(string file){
		XmlDocument doc = new XmlDocument ();
		doc.Load (Application.dataPath.ToString() + "/resources/"+file+".xml");
		
		XmlNodeList nodelist;
		XmlNode root = doc.DocumentElement;
		
		nodelist = root.SelectNodes("example"); //change to node name used in xml
		examples = new Example[nodelist.Count];
		
		for(int i = 0; i < nodelist.Count; ++i){
			//add more lines if you are using more nodes in the xml, convert string to int or float with int.Parse or float.Parse
			int id = int.Parse(nodelist[i].SelectSingleNode("id").InnerText);  //takes the id out of the xml node
			string name =  nodelist[i].SelectSingleNode("name").InnerText; //takes the name out of the xml node 
			examples[i] = new Example(id, name);
		}
	}
}
