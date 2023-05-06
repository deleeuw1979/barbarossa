using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Management;
using System.Runtime.InteropServices;

namespace Barbarossa
{
    class Data
    {
        public static string[][] units = new string[][] 
        {
            //GERMAN
            //Finland
            new string[] { "15th Infantry (Finnish)", "12" },
            new string[] { "10th Infantry (Finnish)", "12" },
            new string[] { "2th Infantry (Finnish)", "12" }, 
            new string[] { "18th Infantry (Finnish)", "12" },
            new string[] { "12th Infantry (Finnish)", "12" },
            //Nord
                new string[] { "1st LuftFlotte", "30" }, //R
            new string[] { "291st Infantry", "18" },
            new string[] { "61st Infantry", "18" },
            new string[] { "217th Infantry", "18" },
            new string[] { "SS Polizei", "25" },
            new string[] { "11th Infantry", "18" },
            new string[] { "1st Infantry", "18" },
            new string[] { "21st Infantry", "18" },            
            new string[] { "1st Panzer", "24" },
                new string[] { "58th Infantry", "18" },//R
                new string[] { "254th Infantry", "18" },//R
            new string[] { "6th Panzer", "24" },  
            new string[] { "269th Infantry", "18" },
            new string[] { "36th Motorized Infantry", "21" },
            new string[] { "290th Infantry", "18" },
            new string[] { "3rd Motorized Infantry", "21" },
                new string[] { "\"Totenkopf\" SS Panzergranadier", "28" },//R
            new string[] { "30th Infantry", "18" },     
            new string[] { "126th Infantry", "18" },
            new string[] { "122nd Infantry", "18" }, 
            new string[] { "123rd Infantry", "18" },
                new string[] { "281st Security", "31" },//R
            new string[] { "121st Infantry (2)", "18" },            
            new string[] { "12th Infantry", "18" },
                new string[] { "206th Infantry", "18" },//R
                new string[] { "251st Infantry", "18" },//R
            new string[] { "32nd Infantry", "18" },   
            new string[] { "253rd Infantry", "18" },                          
                new string[] { "86th Infantry", "18" },//R
                new string[] { "285th Security", "31" },//R            
            //Mitte
                new string[] { "3rd LuftFlotte", "30" },//R
            new string[] { "26th Infantry", "18" },
            new string[] { "6th Infantry", "18" },          
            new string[] { "110th Infantry", "18" },       
            new string[] { "52nd Infantry", "18" },      
                new string[] { "20th Motorized Infantry", "21" },//R
            new string[] { "20th Panzer", "24" },
            new string[] { "7th Panzer", "24" },    
                new string[] { "14th Motorized Infantry", "21" },//R
            new string[] { "35th Infantry", "18" },
            new string[] { "5th Infantry", "18" },
                new string[] { "18th Motorized Infantry", "21" },//R
            new string[] { "12th Panzer", "24" },            
            new string[] { "161st Infantry", "18" },
            new string[] { "28th Infantry", "18" },
            new string[] { "8th Infantry", "18" },
            new string[] { "256th Infantry", "18" },
            new string[] { "162nd Infantry", "18" },
                new string[] { "403rd Security", "31" },//R
            new string[] { "87th Infantry", "18" },
            new string[] { "129th Infantry", "18" },
            new string[] { "102nd Infantry", "18" },
            new string[] { "221st Security", "31" },
            new string[] { "87th Infantry", "18" },         
            new string[] { "121st Infantry (1)", "18" },       
            new string[] { "23rd Infantry", "18" },  
            new string[] { "7th Infantry", "18" },
                new string[] { "258th Infantry", "18" }, //R
                new string[] { "286th Security", "31" }, //R
            new string[] { "268th Infantry", "18" }, 
                new string[] { "17th Infantry", "18" }, //R           
            new string[] { "263rd Infantry", "18" },
            new string[] { "137th Infantry", "18" },
                new string[] { "78th Infantry", "18" }, //R
            new string[] { "292nd Infantry", "18" },
            new string[] { "252nd Infantry", "18" }, 
            new string[] { "134th Infantry", "18" },
            new string[] { "131st Infantry", "18" },
                new string[] { "29th Motorized Infantry", "21" },//R
            new string[] { "167th Infantry", "18" },
                new string[] { "293rd Infantry", "18" }, //R
            new string[] { "17th Panzer", "24" },     
            new string[] { "18th Panzer", "24" },
            new string[] { "31st Infantry", "18" },
            new string[] { "45th Infantry", "18" },
            new string[] { "34th Infantry", "18" },
                new string[] { "10th Motorized Infantry", "21" }, //R   
            new string[] { "3rd Panzer", "24" },
            new string[] { "4th Panzer", "24" },     
            new string[] { "1st Cavalry", "22" },
            new string[] { "267th Infantry", "18" },                      
                new string[] { "10th Panzer", "24" },//R
            new string[] { "255th Infantry", "18" },     
                new string[] { "\"Das Reich\" SS Panzergranadier", "28" }, //R
                new string[] { "294th Infantry", "18" }, //R
            new string[] { "52nd Motorized Infantry (Italian)", "16" },
            new string[] { "9th Motorized Infantry (Italian)", "16" },
            new string[] { "3rd Cavalry (Italian)", "15" },     
            //Süd
                new string[] { "4th LuftFlotte", "30" },//R
            new string[] { "56th Infantry", "18" },
            new string[] { "62nd Infantry", "18" },
            new string[] { "298th Infantry", "18" },    
                new string[] { "14th Panzer ", "24" }, //R   
            new string[] { "44th Infantry", "18" },
                new string[] { "25th Motorized Infantry", "21" },//R
            new string[] { "168th Infantry", "18" },
            new string[] { "299th Infantry", "18" },
                new string[] { "13th Panzer", "24" },//R
                new string[] { "99th Light", "31" }, //R
            new string[] { "111st Infantry", "18" },
            new string[] { "75th Infantry", "18" },
            new string[] { "57th Infantry", "18" },
            new string[] { "297th Infantry", "18" },            
            new string[] { "9th Infantry", "18" },
                new string[] { "11th Panzer", "24" },//R
            new string[] { "262nd Infantry", "18" },
            new string[] { "24th Infantry", "18" },
            new string[] { "295th Infantry", "18" },
                new string[] { "16th Panzer", "24" },//R   
            new string[] { "71st Infantry", "18" },
                new string[] { "296th Infantry", "18" },//R
                new string[] { "16th Motorized Infantry", "21" },//R
                new string[] { "97th Light", "31" },//R
            new string[] { "1st Mountain", "20" },
            new string[] { "68th Infantry", "18" },
            new string[] { "257th Infantry", "18" },
            new string[] { "101st Light", "31" },
            new string[] { "454th Security", "31" },
            new string[] { "22nd Infantry", "18" },  
            new string[] { "72nd Infantry", "18" },            
            new string[] { "76th Infantry", "18" },
            new string[] { "95th Infantry", "18" },            
            new string[] { "113th Infantry", "18" },
            new string[] { "213th Security", "31" },
            new string[] { "\"Wiking\" SS Infantry", "25" },
            new string[] { "125th Infantry", "18" },
            new string[] { "239th Infantry", "18" },            
            new string[] { "198th Infantry", "18" },            
            new string[] { "100th Light", "31" },
            new string[] { "444th Security", "31" },            
            new string[] { "170th Infantry", "18" },
            new string[] { "132nd Infantry", "18" },
            new string[] { "50th Infantry", "18" },            
            new string[] { "94th Infantry", "18" },                        
            new string[] { "24th Infantry", "18" },            
            new string[] { "46th Infantry", "18" },
            new string[] { "60th Infantry", "18" },
            new string[] { "7th Infantry (Rumanian)", "13" },
            new string[] { "1st Mountain (Rumanian)", "14" },            
            new string[] { "14th Infantry (Rumanian)", "13" },
            new string[] { "1st Cavalry (Rumanian)", "15" },            
            //RUSSIAN
            //Leningrad
            new string[] { "19th Rifle", "2" },
            new string[] { "1st Mechanized Rifle", "5" },//Pskov 61,1700-*311-733
            new string[] { "42nd Rifle", "2" }, 
            new string[] { "10th Mechanized Rifle", "5" },                       
            new string[] { "50th Rifle", "2" },
            //Baltic
            new string[] { "10th Rifle", "2" },
            new string[] { "12th Mechanized Rifle", "5" },//SW Riga(?)  948,2710-*398-951          
            new string[] { "11th Rifle", "2" },//Grodno   978,2670-*654-949  
            new string[] { "16th Rifle", "2" },
            new string[] { "3rd Mechanized Rifle", "5" },            
            new string[] { "29th Rifle", "2" }, //Vilnius 1098,2618-*588-899 
                //Baltic Reserve
            new string[] { "24th Rifle", "2" }, //W Pskov 61,1700-*311-733
            new string[] { "22nd Rifle", "2" }, //W Pskov 61,1700-*311-733            
            new string[] { "5th Airborne", "3" },                        
            //Western
            new string[] { "4th Rifle", "2" },
            new string[] { "21st Rifle", "2" }, //S Vilnius 1200,2643-*588-899 
            new string[] { "11th Mechanized Rifle", "5" },  
            new string[] { "1st Cavalry", "4" },
            new string[] { "1st Rifle", "2" },            
            new string[] { "5th Rifle", "2" },
            new string[] { "6th Mechanized Rifle", "5" },  //B'stock  1366, 2727-*698-1007           
            new string[] { "13th Mechanized Rifle", "5" },  //B'stock  1425,2724-*698-1007
            new string[] { "28th Rifle", "2" },
            new string[] { "14th Mechanized Rifle", "5" },  
            new string[] { "27th Rifle", "2" },            
                //Western Reserve            
            new string[] { "6th Cavalry", "4" },
            new string[] { "2nd Rifle", "2" }, //Minsk 1242,2527-*698-1007
            new string[] { "17th Mechanized Rifle", "5" }, //Minsk/Vilnius  1306,2566-*698-1007(*588-899)
            new string[] { "47th Rifle", "2" },  //Bara'vici 1365,2555-*723-907   
            new string[] { "20th Mechanized Rifle", "5" },  //Minsk 1424,2547
            new string[] { "4th Airborne", "3" }, //Minsk 1494,2544-*698-1007
            new string[] { "31st Rifle", "2" },            
            new string[] { "44th Rifle", "2" }, //Minsk 1623,2571-*698-1007
            //SouthWest            
            new string[] { "1st Airborne", "3" },
            new string[] { "3rd Airborne", "3" },
            new string[] { "5th Cavalry", "4" },  //O Rovne  1745,2675-*960-961 
            new string[] { "13th Mechanized Rifle", "5" },  
            new string[] { "18th Mechanized Rifle", "5" },              
            new string[] { "9th Rifle", "2" },  //W Zhitomir 2003,2670-*1030-868
            new string[] { "14th Rifle", "2" }, //O Brest  2103,2643-*757-996        
            new string[] { "26th Rifle", "2" },
            new string[] { "48th Rifle", "2" },
            new string[] { "49th Rifle", "2" }, //S Proskuriv 2336,2593-*1085-797
            new string[] { "47th Rifle", "2" },            
            new string[] { "4th Rifle", "2" },
            new string[] { "35th Rifle", "2" },            
            //Kiev
            new string[] { "15th Rifle", "2" },  //N Tarnopol 2510,2453-*1040-983
            new string[] { "22nd Mechanized Rifle", "5" },  //Rovne  2553,2438-*960-961                     
            new string[] { "31st Rifle", "2" }, //S Pinsk 2632,2424-*960-961
            new string[] { "27th Rifle", "2" },  //S Rovne 2692,2410-*960-961
            new string[] { "15th Mechanized Rifle", "5" },  
            new string[] { "6th Rifle", "2" },
            new string[] { "4th Mechanized Rifle", "5" },  
            new string[] { "8th Rifle", "2" },
            new string[] { "13th Rifle", "2" },   //S Lwow 2977,2302-*1001-1035
            new string[] { "8th Mechanized Rifle", "5" }, 
            new string[] { "16th Mechanized Rifle", "5" },  
            new string[] { "17th Rifle", "2" },
                //Kiev Reserve
            new string[] { "37th Rifle", "2" }, //Proskuriv 2710,2265-*1085-797
            new string[] { "24th Mechanized Rifle", "5" }, //Proskuriv 2553,2344-*1085-797             
            new string[] { "9th Mechanized Rifle", "5" }, //O Rovne 2422, 2426-*960-961 
            new string[] { "36th Rifle", "2" }, //W Zhitomir 2252,2446-*1030-868
            new string[] { "19th Mechanized Rifle", "5" }, //S Zhitomir 2351,2288-*1030-868
            new string[] { "55th Rifle", "2" }, //Vinnitza    1174,1112-*1135-886
            //Reserve
            new string[] { "2nd Airborne", "3" },
            new string[] { "7th Mechanized Rifle", "5" }, 
            new string[] { "21st Mechanized Rifle", "5" },  
            new string[] { "23th Mechanized Rifle", "5" },  
            new string[] { "25th Mechanized Rifle", "5" },
            new string[] { "20th Rifle", "2" },
            new string[] { "25th Rifle", "2" },
            new string[] { "30th Rifle", "2" },
            new string[] { "32nd Rifle", "2" },
            new string[] { "33rd Rifle", "2" },
            new string[] { "34th Rifle", "2" },
            new string[] { "41st Rifle", "2" },
            new string[] { "45th Rifle", "2" },
            new string[] { "51st Rifle", "2" },
            new string[] { "52nd Rifle", "2" },
            new string[] { "53rd Rifle", "2" },
            new string[] { "61st Rifle", "2" },
            new string[] { "62nd Rifle", "2" },
            new string[] { "63rd Rifle", "2" },
            new string[] { "66th Rifle", "2" },
            new string[] { "67th Rifle", "2" },
            new string[] { "69th Rifle", "2" },
            //Caucasus
            new string[] { "3rd Rifle", "2" },
            new string[] { "23th Rifle", "2" },
            new string[] { "40th Rifle", "2" },
            new string[] { "64th Rifle", "2" },
            new string[] { "5th Mechanized Rifle", "5" },  //Bessarabia
            new string[] { "28th Mechanized Rifle", "5" },  
            new string[] { "26th Mechanized Rifle", "5" },        
            //7-41
            new string[] { "93rd Infantry", "18" },  
            new string[] { "15th Infantry", "18" },
            new string[] { "98th Infantry", "18" },
            new string[] { "197th Infantry", "18" },
            new string[] { "4th Mountain", "20" },
            new string[] { "8th Panzer", "24" },
            new string[] { "9th Panzer", "24" },            
            new string[] { "19th Panzer", "24" },
            new string[] { "1st Infantry (Hungarian)", "13" },
            new string[] { "1st Armored Infantry (Hungarian)", "16" },
            //8-41
            new string[] { "73rd Infantry", "18" },
            new string[] { "79th Infantry", "18" },
            new string[] { "96th Infantry", "18" },
            new string[] { "106th Infantry", "18" },
            new string[] { "183rd Infantry", "18" },
            new string[] { "707th Infantry", "18" },
            new string[] { "112th Infantry", "18" },
            new string[] { "260th Infantry", "18" },
            new string[] { "6th Infantry (Rumanian)", "13" },
            new string[] { "7th Infantry (Rumanian)", "13" },
            //9-41
            new string[] { "339th Infantry", "18" },
            new string[] { "2nd Infantry (Italian)", "13" },
            new string[] { "3rd Infantry (Italian)", "13" },
            new string[] { "5th Infantry (Italian)", "13" },
            new string[] { "250th Infantry (Spanish)", "13" },
            new string[] { "38th Rifle", "2" },
            //10-41
            new string[] { "2nd Panzer", "24" },
            new string[] { "5th Panzer", "24" },
	        new string[] { "6th Airborne", "3" },
            new string[] { "7th Airborne", "3" },
            new string[] { "8th Airborne", "3" },
            new string[] { "9th Airborne", "3" },
            //11-41
            new string[] { "223th Infantry", "18" },
            new string[] { "227th Infantry", "18" },
            new string[] { "60th Motorized Infantry", "21" },
	        new string[] { "10th Airborne", "3" },
            //12-41
            new string[] { "212th Infantry", "18" },
            new string[] { "215th Infantry", "18" },
  	        new string[] { "3rd Cavalry", "4" },
            //1-42
            new string[] { "81st Infantry", "18" },
            new string[] { "83rd Infantry", "18" },
            new string[] { "88th Infantry", "18" },
            new string[] { "225th Infantry", "18" },
            new string[] { "2nd Cavalry", "4" },
            new string[] { "15th Cavalry", "4" },
            //2-42
            new string[] { "208th Infantry", "18" },
            new string[] { "211th Infantry", "18" },
            new string[] { "218th Infantry", "18" },
            new string[] { "246th Infantry", "18" },
            new string[] { "330th Infantry", "18" },
            new string[] { "205th Infantry", "18" },
            new string[] { "8th Cavalry", "4" },
            new string[] { "9th Cavalry", "4" },
            new string[] { "11th Cavalry", "4" },
            new string[] { "12th Cavalry", "4" },
            new string[] { "13th Cavalry", "4" },
            new string[] { "14th Cavalry", "4" },
            new string[] { "17th Cavalry", "4" },
            //3-42    
            new string[] { "329th Infantry", "18" },
            new string[] { "331st Infantry", "18" },
            new string[] { "342nd Infantry", "18" },
            new string[] { "383rd Infantry", "18" },
            new string[] { "22nd Panzer", "24" },
            new string[] { "1st Guard Cavalry", "9" },
            //4-42
            new string[] { "38th Infantry", "18" },
            new string[] { "387th Infantry", "18" },
            new string[] { "5th Mountain", "20" },          
            new string[] { "23rd Panzer", "24" },
            new string[] { "8th Guard Rifle", "7" },
            new string[] { "1st Tank", "6" },
            new string[] { "3rd Tank", "6" },
            new string[] { "4th Tank", "6" },
            //5-42
            new string[] { "305th Infantry", "18" },
            new string[] { "323rd Infantry", "18" },
            new string[] { "336th Infantry", "18" },
            new string[] { "384th Infantry", "18" },            
            new string[] { "385th Infantry", "18" },
            new string[] { "389th Infantry", "18" },
            new string[] { "5th Cavalry (Rumanian)", "15" },            
            new string[] { "6th Cavalry (Rumanian)", "15" },
            new string[] { "9th Cavalry (Rumanian)", "15" },
            new string[] { "2nd Mountain (Rumanian)", "14" },
            new string[] { "1st Armored (Hungarian)", "17" },
            new string[] { "2nd Tank", "6" },
            new string[] { "5th Tank", "6" },
            new string[] { "6th Tank", "6" },
            new string[] { "7th Tank", "6" },
            new string[] { "8th Tank", "6" },
            new string[] { "21st Tank", "6" },
            new string[] { "22nd Tank", "6" },
            new string[] { "23rd Tank", "6" },
            new string[] { "24th Tank", "6" },
            new string[] { "18th Cavalry", "4" },
            //6-42
            new string[] { "2nd Mountain (Italian)", "14" },
            new string[] { "3rd Mountain (Italian)", "14" },
            new string[] { "4th Mountain (Italian)", "14" },
            new string[] { "156th Infantry (Italian)", "13" },               
            new string[] { "82nd Infantry", "18" },
            new string[] { "371st Infantry", "18" },
            new string[] { "376th Infantry", "18" },
            new string[] { "377th Infantry", "18" },
            new string[] { "1st Armored (Rumanian)", "17" },
            new string[] { "203rd Security", "31" },
            new string[] { "9th Guard Rifle", "7" },
            new string[] { "11th Guard Mechanized Rifle", "10" },
            new string[] { "10th Tank", "6" },
            new string[] { "11th Tank", "6" },
            new string[] { "12th Tank", "6" },
            new string[] { "13th Tank", "6" },
            new string[] { "14th Tank", "6" },
            new string[] { "15th Tank", "6" },
            //7-42
            new string[] { "370th Infantry", "18" },
            new string[] { "216th Infantry", "18" },
            new string[] { "328th Infantry", "18" },
            new string[] { "340th Infantry", "18" },
            new string[] { "201st Security", "31" },
            new string[] { "1st Jäger", "20" },
            new string[] { "2nd Jäger", "20" },
            new string[] { "6th Infantry (Hungarian)", "13" },            
            new string[] { "7th Infantry (Hungarian)", "13" },
            new string[] { "9th Infantry (Hungarian)", "13" },
            new string[] { "16th Tank", "6" },
            new string[] { "17th Tank", "6" },
            new string[] { "18th Tank", "6" },
            new string[] { "27th Tank", "6" },
            //8-42 
            new string[] { "25th Tank", "6" },
            new string[] { "26th Tank", "6" },
            new string[] { "28th Tank", "6" },
            //9-42
            new string[] { "11th Infantry (Rumanian)", "13" },
            new string[] { "13th Infantry (Rumanian)", "13" },
            new string[] { "14th Infantry (Rumanian)", "13" },
            new string[] { "3rd Mountain", "20" },  
            //10-42
            new string[] { "SS Cavalry", "27" },
            //11-42
            new string[] { "337th Infantry", "18" },
            new string[] { "1st Guard Mechanized Rifle", "10" },
            new string[] { "1st Guard Rifle", "7" },
            new string[] { "2nd Guard Rifle", "7" },
            new string[] { "4th Guard Rifle", "7" },
            new string[] { "6th Guard Rifle", "7" },
            //12-42
            new string[] { "306th Infantry", "18" },
            new string[] { "50th Guard Rifle", "7" },
            new string[] { "13th Guard Rifle", "7" },
            //1-43            
            new string[] { "207th Security", "31" },
            new string[] { "69th Infantry", "18" },
            new string[] { "321st Infantry", "18" },
            new string[] { "302nd Infantry", "18" },
            new string[] { "304th Infantry", "18" },
            new string[] { "\"von Stumpefeldt\" Infantry", "18"  },
            new string[] { "19th Tank", "6" },
            new string[] { "20th Tank", "6" },
            new string[] { "12th Guard Rifle", "7" },
            new string[] { "7th Cavalry", "4" },
            //2-43
            new string[] { "\"Leibstandarte Adolf Hitler\" SS Panzer Grenadier", "28" },
            new string[] { "333rd Infantry", "18" },
            new string[] { "335rd Infantry", "18" },
            new string[] { "320th Infantry", "18" },
            //3-43
            new string[] { "327th Infantry", "18" },
            new string[] { "19th Cavalry", "4" },
            new string[] { "29th Tank", "6" },
            //4-43
            new string[] { "332nd Infantry", "18" },
            new string[] { "39th Infantry", "18" },
            new string[] { "282nd Infantry", "18" },
            new string[] { "30th Tank", "6" },
            new string[] { "7th Guard Rifle", "7" },
            new string[] { "15th Guard Rifle", "7" },
            new string[] { "17th Guard Rifle", "7" },
            new string[] { "18th Guard Rifle", "7" },            
            new string[] { "19th Guard Rifle", "7" },
            new string[] { "20th Guard Rifle", "7" },
            new string[] { "21st Guard Rifle", "7" },
            new string[] { "22nd Guard Rifle", "7" },            
            new string[] { "23th Guard Rifle", "7" },
            new string[] { "24th Guard Rifle", "7" },
            new string[] { "25th Guard Rifle", "7" },
            new string[] { "31st Guard Rifle", "7" },            
            new string[] { "32nd Guard Rifle", "7" },
            new string[] { "33rd Guard Rifle", "7" },
            //5-43 (none)
            //6-43
            new string[] { "\"Grossdeutschland\" Panzergrenadier ", "23" },
            new string[] { "31st Tank", "6" },
            new string[] { "10th Guard Rifle", "7" },
            //7-43
            new string[] { "355th Infantry", "18" },
            new string[] { "6th Guard Mechanized Rifle", "10" },
            //8-43 (none)
            //9-43
            new string[] { "321st Infantry", "18" },
            //10-43 (none)
            //11-43
            new string[] { "1st Luftwaffe Field", "19" },
            new string[] { "4th Luftwaffe Field", "19" },
            new string[] { "5th Luftwaffe Field", "19" },
            new string[] { "6th Luftwaffe Field", "19" },
            new string[] { "9th Luftwaffe Field", "19" },
            new string[] { "10th Luftwaffe Field", "19" },
            new string[] { "12th Luftwaffe Field", "19" },
            new string[] { "13th Luftwaffe Field", "19" },
            new string[] { "21st Luftwaffe Field", "19" },
            //12-43
            new string[] { "25th Panzer", "24" },
            new string[] { "15th SS Infantry (Lithuanian)", "26" },
            new string[] { "5th Guard Cavalry", "9" },
            //1-44
            new string[] { "357st Infantry", "18" },
            new string[] { "359st Infantry", "18" },
            //2-44
            new string[] { "20th Ski Infantry", "18" },
            //3-44
            new string[] { "20th SS Infantry (Estonian)", "26" },
            //4-44
            new string[] { "214th Infantry", "18" },
            new string[] { "361th Infantry", "18" },
            new string[] { "367th Infantry", "18" },
            new string[] { "9th \"Hohenstaufen\" SS Panzer", "29" },
            new string[] { "10th \"Frundsberg\" SS Panzer", "29" },
            new string[] { "349th Infantry", "18" },
            new string[] { "19 SS Infantry (Lithuanian) ", "26" },            
            new string[] { "16th \"Reichsführer SS\" SS Panzergrenadier", "28" },
            //5-44
            new string[] { "52nd Security", "31" },
            new string[] { "391st Security", "31" },
            //6-44 (none)
            //7-44
            new string[] { "14th \"Galizien\" SS Infantry (Ukranian) ", "26" },
            new string[] { "18th \"Horst Wessel\" SS Panzergrenadier", "28" },            
            new string[] { "22nd \"Maria Theresia\" SS Cavalry", "27" },
            //8-44
            new string[] { "196th Infantry", "18" },
            new string[] { "6th Grenadier", "18" },
            new string[] { "541st Grenadier", "18" },
            new string[] { "544th Grenadier", "18" },
            new string[] { "545th Grenadier", "18" },
            new string[] { "547th Grenadier", "18" },
            new string[] { "548th Grenadier", "18" },
            new string[] { "549th Grenadier", "18" },
            new string[] { "551st Grenadier", "18" },
            new string[] { "558th Grenadier", "18" },
            new string[] { "561st Grenadier", "18" },
            new string[] { "562nd Grenadier", "18" },
            new string[] { "563th Grenadier", "18" },
            //9-44 (none)
            //10-44 (none)
            //11-44
            new string[] { "31st SS Grenadier ", "25" },
            new string[] { "71st Infantry", "18" },
            //12-44
            new string[] { "711th Infantry", "18" },
            //1-45 
            new string[] { "344th Infantry", "18" },
            //2-45
            new string[] { "32th \"30 Januar\" SS Grenadier", "25" },
            new string[] { "28th \"Wallonien\" SS Grenadier (Wallonian)", "26" },
            new string[] { "27th \"Langemarck\" SS Grenadier", "25" },
            new string[] { "33rd \"Charlemagne\" SS Grenadier (French)", "26" },
            new string[] { "12th \"Hitlerjugend\" SS Panzergrenadier", "28" },
            new string[] { "23rd \"Nederland\" SS Grenadier (Dutch)", "26" },
            new string[] { "356th Infantry", "18" },
            new string[] { "386th Infantry", "18" },
            new string[] { "381st Infantry", "18" },
            new string[] { "153rd Infantry", "18" },
            new string[] { "\"Führer\" Grenadier", "18" },
            new string[] { "\"Kurmark\" Grenadier", "18" },            
            new string[] { "\"Raegener\" Infantry", "18" },
            new string[] { "\"Matterstock\" Infantry", "18" },
            new string[] { "\"Köslin\" Infantry", "18" },
            new string[] { "\"Deneke\" Infantry", "18" },
            new string[] { "\"Bärwalde\" Infantry", "18" },
            //3-45
            new string[] { "\"Pommernland\" Infantry", "18" }, 
            new string[] { "\"Führer Begleit\" Infantry", "18" }, 
            new string[] { "309th Infantry", "18" },
            new string[] { "275th Infantry", "18" },
            new string[] { "303rd Infantry", "18" },
            new string[] { "35th SS Grenadier", "25" },
            new string[] { "3rd Cavalry", "22" },
            new string[] { "4th Cavalry", "22" },
            new string[] { "232nd Panzer", "24" },
            new string[] { "650th Infantry, Russian", "13" },
            //4-45
            new string[] { "715th Infantry", "18" },
            new string[] { "600th Infantry", "18" }
        };

        public static string[][][] unitTypes = new string[][][]
        {
            new string[][]{},
            new string[][]{new string[]{"Partisan","P"},new string[]{"150","20","30"},new string[]{"133","20","20"},new string[]{"145","30","30"},new string[]{"100","10","20"},new string[]{"125","40","30"},new string[]{"125","45","35"},new string[]{"150","20","30"},new string[]{"100","10","30"},new string[]{"100","30","40"},new string[]{"90","10","20"},new string[]{"133","40","50"},new string[]{"100","40","50"},new string[]{"133","30","50"}},
            new string[][]{new string[]{"Russian Infantry","RUinf"},new string[]{"50","60","60"},new string[]{"45","55","60"},new string[]{"45","55","65"},new string[]{"30","40","50"},new string[]{"35","45","55"},new string[]{"40","40","50"},new string[]{"50","60","65"},new string[]{"40","50","65"},new string[]{"45","50","70 "},new string[]{"30","40","60 "},new string[]{"35","45","75"},new string[]{"35","40","85"},new string[]{"30","35","55"}},
            new string[][]{new string[]{"Russian Airborne", "RUfj"},new string[]{"55","50","45"},new string[]{"55","50","40"},new string[]{"50","50","45"},new string[]{"40","45","45"},new string[]{"45","50","45"},new string[]{"50","55","50"},new string[]{"60","50","40"},new string[]{"40","40","40"},new string[]{"45","40","45"},new string[]{"35","40","40"},new string[]{"40","35","45"},new string[]{"40","30","35"},new string[]{"35","35","40"}},
            new string[][]{new string[]{"Russian Cavalry","RUkav"},new string[]{"80","70","40"},new string[]{"65","60","35"},new string[]{"70","65","30"},new string[]{"45","40","25"},new string[]{"50","65","35"},new string[]{"60","70","40"},new string[]{"80","70","40"},new string[]{"10","10","20"},new string[]{"40","20","10"},new string[]{"20","10","20"},new string[]{"10","5","10"},new string[]{"30","10","20"},new string[]{"15","10","10"}},
            new string[][]{new string[]{"Russian Mot. Infantry", "RUmot"},new string[]{"80","65","70"},new string[]{"80","65","70"},new string[]{"80","55","65"},new string[]{"30","25","30"},new string[]{"50","35","40"},new string[]{"60","40","50"},new string[]{"80","65","70"},new string[]{"20","20","70"},new string[]{"50","25","60"},new string[]{"10","10","30"},new string[]{"30","10","30"},new string[]{"40","20","40"},new string[]{"20","10","40"}},
            new string[][]{new string[]{"Russian Tank", "RUpz"},new string[]{"80","80","90"},new string[]{"80","80","90"},new string[]{"80","80","80"},new string[]{"30","30","40"},new string[]{"50","40","50"},new string[]{"60","45","55"},new string[]{"80","80","90"},new string[]{"20","70","70"},new string[]{"50","50","60"},new string[]{"10","20","20"},new string[]{"30","20","30"},new string[]{"40","40","50"},new string[]{"20","30","30"}},
            new string[][]{new string[]{"Guard Infantry","GDinf"},new string[]{"60","65","65"},new string[]{"55","60","65"},new string[]{"55","60","70"},new string[]{"30","40","55"},new string[]{"45","50","60"},new string[]{"50","55","65"},new string[]{"50","65","70"},new string[]{"40","55","70"},new string[]{"55","55","65"},new string[]{"30","45","65"},new string[]{"35","50","80"},new string[]{"45","45","90"},new string[]{"30","35","60"}},
            new string[][]{new string[]{"Guard Airborne","GDfj"},new string[]{"60","55","50"},new string[]{"60","55","45"},new string[]{"55","55","50"},new string[]{"45","50","50"},new string[]{"50","55","50"},new string[]{"55","60","55"},new string[]{"65","55","45"},new string[]{"45","45","45"},new string[]{"50","45","50"},new string[]{"40","45","45"},new string[]{"45","40","50"},new string[]{"45","35","40"},new string[]{"40","40","45"}},
            new string[][]{new string[]{"Guard Cavalry","GDkav"},new string[]{"85","75","45"},new string[]{"65","65","40"},new string[]{"80","70","35"},new string[]{"45","45","30"},new string[]{"50","75","40"},new string[]{"60","80","45"},new string[]{"85","75","45"},new string[]{"15","15","25"},new string[]{"45","25","15"},new string[]{"20","15","25"},new string[]{"10","10","15"},new string[]{"30","15","25"},new string[]{"15","15","15"}},
            new string[][]{new string[]{"Guard Mechanized","GDmech"},new string[]{"80","70","75"},new string[]{"80","70","75"},new string[]{"80","60","70"},new string[]{"30","30","35"},new string[]{"50","40","45"},new string[]{"60","45","55"},new string[]{"80","70","75"},new string[]{"20","25","75"},new string[]{"50","30","65"},new string[]{"10","15","30"},new string[]{"30","20","35"},new string[]{"40","30","45"},new string[]{"20","20","45"}},
            new string[][]{new string[]{"Guard Tank","GDpz"},new string[]{"85","85","95"},new string[]{"85","85","95"},new string[]{"85","85","85"},new string[]{"35","35","45"},new string[]{"55","45","55"},new string[]{"65","55","65"},new string[]{"85","85","95"},new string[]{"35","75","75"},new string[]{"55","55","65"},new string[]{"15","25","25"},new string[]{"35","25","35"},new string[]{"45","45","55"},new string[]{"25","35","35"}},
            new string[][]{new string[]{"Finnish Infantry","AXfin"},new string[]{"55","70","70"},new string[]{"45","50","55"},new string[]{"45","65","75"},new string[]{"35","50","60"},new string[]{"45","55","65"},new string[]{"50","50","60"},new string[]{"55","60","65"},new string[]{"45","50","65"},new string[]{"50","50","70"},new string[]{"40","40","60"},new string[]{"45","45","75"},new string[]{"40","40","80"},new string[]{"30","35","55"}},
            new string[][]{new string[]{"Axis Infantry","AXinf"},new string[]{"45","60","60"},new string[]{"45","55","60"},new string[]{"45","55","65"},new string[]{"30","40","50"},new string[]{"35","45","55"},new string[]{"40","40","50"},new string[]{"50","60","65"},new string[]{"40","50","65"},new string[]{"45","50","70"},new string[]{"30","40","60"},new string[]{"35","45","75"},new string[]{"35","40","85"},new string[]{"30","35","55"}},
            new string[][]{new string[]{"Axis Mountain Infantry","AXgeb"},new string[]{"50","60","60"},new string[]{"45","55","60"},new string[]{"45","55","65"},new string[]{"30","40","50"},new string[]{"35","45","55"},new string[]{"40","40","50"},new string[]{"50","60","65"},new string[]{"40","50","65"},new string[]{"45","50","70"},new string[]{"30","40","60"},new string[]{"35","45","75"},new string[]{"35","40","85"},new string[]{"30","35","55"}},
            new string[][]{new string[]{"Axis Cavalry","AXkav"},new string[]{"80","70","40"},new string[]{"65","60","35"},new string[]{"70","65","30"},new string[]{"45","40","25"},new string[]{"50","65","35"},new string[]{"60","70","40"},new string[]{"80","70","40"},new string[]{"10","10","20"},new string[]{"40","20","10"},new string[]{"20","10","20"},new string[]{"10","5","10"},new string[]{"30","10","20"},new string[]{"15","10","10"}},
            new string[][]{new string[]{"Axis Mot. Infantry", "AXmot"},new string[]{"60","65","65"},new string[]{"60","65","65"},new string[]{"40","60","65"},new string[]{"10","20","45"},new string[]{"20","30","50"},new string[]{"50","45","55"},new string[]{"60","65","70"},new string[]{"20","60","75"},new string[]{"50","55","65"},new string[]{"10","35","65"},new string[]{"20","40","70"},new string[]{"55","45","90"},new string[]{"20","30","60"}},
            new string[][]{new string[]{"Axis Armor","AXpz"},new string[]{"80","80","90"},new string[]{"80","80","90"},new string[]{"80","80","80"},new string[]{"30","30","40"},new string[]{"50","40","50"},new string[]{"60","45","55"},new string[]{"80","80","90"},new string[]{"20","70","70"},new string[]{"50","50","60"},new string[]{"5","20","20"},new string[]{"10","20","30"},new string[]{"40","40","50"},new string[]{"15","30","30"}},
            new string[][]{new string[]{"German Infantry","GEinf"},new string[]{"85","95","95"},new string[]{"80","90","95"},new string[]{"85","85","90"},new string[]{"35","20","25"},new string[]{"50","30","35"},new string[]{"65","40","45"},new string[]{"85","95","95"},new string[]{"30","75","80"},new string[]{"50","55","60"},new string[]{"15","20","25"},new string[]{"30","25","35"},new string[]{"45","45","55"},new string[]{"20","35","45"}},
            new string[][]{new string[]{"German Luftwaffe Infantry","GElw"},new string[]{"75","55","65"},new string[]{"70","50","65"},new string[]{"75","45","60"},new string[]{"30","10","15"},new string[]{"45","10","25"},new string[]{"60","10","30"},new string[]{"75","55","65"},new string[]{"20","35","45"},new string[]{"45","25","40"},new string[]{"15","10","15"},new string[]{"30","15","30"},new string[]{"45","35","50"},new string[]{"20","30","35"}},
            new string[][]{new string[]{"German Mountain Infantry","GEgeb"},new string[]{"75","60","70"},new string[]{"75","55","70"},new string[]{"85","50","70"},new string[]{"40","15","20"},new string[]{"55","15","35"},new string[]{"70","15","40"},new string[]{"80","60","70"},new string[]{"30","40","40"},new string[]{"55","25","35"},new string[]{"20","15","15"},new string[]{"40","35","35"},new string[]{"55","35","45"},new string[]{"30","40","40"}},
            new string[][]{new string[]{"German Mot. Infantry","GEmot"},new string[]{"90","100","100"},new string[]{"90","100","100"},new string[]{"85","95","100"},new string[]{"20","25","30"},new string[]{"35","35","40"},new string[]{"50","45","55"},new string[]{"90","100","100"},new string[]{"40","80","80"},new string[]{"50","55","60"},new string[]{"5","10","15"},new string[]{"20","25","30"},new string[]{"50","45","55"},new string[]{"15","25","30"}},
            new string[][]{new string[]{"German Cavalry","GEkav"},new string[]{"85","75","40"},new string[]{"55 ","60","35"},new string[]{"70","65","30"},new string[]{"35","30","25"},new string[]{"35","40","35"},new string[]{"35","65","40"},new string[]{"85","75","40"},new string[]{"5","10","20"},new string[]{"35","20","10"},new string[]{"5","5","5"},new string[]{"5","5","5"},new string[]{"20","10","20"},new string[]{"5","10","5"}},
            new string[][]{new string[]{"German Panzer Grenadier","GEpzgr"},new string[]{"95","100","110"},new string[]{"95","100","110"},new string[]{"95","95","110"},new string[]{"15","10","15"},new string[]{"30","20","25"},new string[]{"55","35","45"},new string[]{"95","100","110"},new string[]{"50","70","80"},new string[]{"45","60","65"},new string[]{"5","10","15"},new string[]{"15","20","25"},new string[]{"45","40","50"},new string[]{"10","15","25"}},
            new string[][]{new string[]{"German Panzer","GEpz"},new string[]{"105","115","110"},new string[]{"105","115","110"},new string[]{"105","110","105"},new string[]{"10","10","20"},new string[]{"25","20","30"},new string[]{"60","40","55"},new string[]{"105","115","110"},new string[]{"80","85","120"},new string[]{"55","65","80"},new string[]{"5","10","15"},new string[]{"10","30","20"},new string[]{"50","45","40"},new string[]{"15","25","30"}},
            new string[][]{new string[]{"SS Infantry","SSinf"},new string[]{"90","105","115"},new string[]{"85","100","115"},new string[]{"85","95","115"},new string[]{"35","25","30"},new string[]{"55","35","40"},new string[]{"65","45","50"},new string[]{"90","105","115"},new string[]{"30","80","100"},new string[]{"55","60","70"},new string[]{"15","25","35"},new string[]{"30","30","45"},new string[]{"50","50","65"},new string[]{"20","40","50"}},
            new string[][]{new string[]{"SS Infantry (Foreign)","SSinfHW"},new string[]{"85","100","105"},new string[]{"80","95","105"},new string[]{"85","95","105"},new string[]{"35","20","30"},new string[]{"50","30","40"},new string[]{"65","40","50"},new string[]{"85","100","105"},new string[]{"30","75","85"},new string[]{"50","55","65"},new string[]{"15","20","30"},new string[]{"30","25","40"},new string[]{"45","45","60"},new string[]{"20","35","50"}},
            new string[][]{new string[]{"SS Cavalry","SSkav"},new string[]{"90","85","50"},new string[]{"60","70","45"},new string[]{"75","75","40"},new string[]{"40","40","35"},new string[]{"40","50","45"},new string[]{"40","75","50"},new string[]{"90","85","50"},new string[]{"10","20","30"},new string[]{"40","30","20"},new string[]{"10","10","15"},new string[]{"5","10","10"},new string[]{"25","20","30"},new string[]{"5","20","15"}},
            new string[][]{new string[]{"SS Panzer Grenadier","SSpg"},new string[]{"100","110","115"},new string[]{"100","110","115"},new string[]{"100","105","115"},new string[]{"20","15","20"},new string[]{"35","25","30"},new string[]{"60","40","50"},new string[]{"100","110","115"},new string[]{"55","75","85"},new string[]{"50","70","75"},new string[]{"5","10","20"},new string[]{"15","25","30"},new string[]{"50","50","60"},new string[]{"10","20","30"}},
            new string[][]{new string[]{"SS Panzer","SSpz"},new string[]{"115","125","115"},new string[]{"115","125","115"},new string[]{"110","120","105"},new string[]{"10","15","20"},new string[]{"25","25","30"},new string[]{"65","45","60"},new string[]{"115","125","115"},new string[]{"85","90","120"},new string[]{"50","75","70"},new string[]{"5","20","10"},new string[]{"15","35","25"},new string[]{"45","55","45"},new string[]{"10","30","35"}},
            new string[][]{new string[]{"German Luftflotte","GElf"},new string[]{"150","140","15"},new string[]{"145","135","15"},new string[]{"15","80","10"},new string[]{"150","130","5"},new string[]{"150","140","10"},new string[]{"0","0","0"},new string[]{"150","135","15"},new string[]{"150","135","0"},new string[]{"145","85","0"},new string[]{"150","150","0"},new string[]{"140","65","0"},new string[]{"145","75","0"},new string[]{"100","30","0"}},             
            new string[][]{new string[]{"German Light/Security Infantry","GEgeb"},new string[]{"80","50","60"},new string[]{"75","45","60"},new string[]{"80","40","65"},new string[]{"30","10","15"},new string[]{"40","10","30"},new string[]{"70","10","40"},new string[]{"80","50","60"},new string[]{"25","30","35"},new string[]{"50","20","30"},new string[]{"15","5","10"},new string[]{"25","20","15"},new string[]{"55","30","45"},new string[]{"15","20","25"}},
            new string[][]{new string[]{"Supply",""},new string[]{"60","0","0"},new string[]{"60","0","0"},new string[]{"40","0","0"},new string[]{"10","0","0"},new string[]{"20","0","0"},new string[]{"50","0","0"},new string[]{"60","0","0"},new string[]{"20","0","0"},new string[]{"50","0","0"},new string[]{"5","0","0"},new string[]{"10","0","0"},new string[]{"40","0","0"},new string[]{"15","0","0"}}
        };

        public static List<string> conditions = new List<string>() { "Calm", "Heat", "Rain", "Mud", "Snow", "Snowing", "Clear", "River", "Town", "Swamp", "Woods", "City", "Mountains" };
        public static string[] weatherConditions = new string[] { "Snowing", "Rain", "Calm", "Heat" };
        public static string[] groundConditions = new string[] { "Mud", "Snow" };

        
        
        
        
        public static int[][] weather = new int[][]
        {
            new int[]{97,101,100,101}, 
            new int[]{95,101,100,101}, 
            new int[]{95,101,100,101}, 
            new int[]{93,101,100,101}, 
            new int[]{90,101,100,101}, 
            new int[]{90,91,100,101}, 
            new int[]{90,93,100,101}, 
            new int[]{85,93,100,101}, 
            new int[]{75,90,100,101}, 
            new int[]{60,90,100,101},
            new int[]{60,90,100,101},
            new int[]{55,80,100,101},
            new int[]{50,80,100,101},
            new int[]{40,70,99,100},
            new int[]{30,60,99,100}, 
            new int[]{20,60,99,100},
            new int[]{10,55,95,100},
            new int[]{5,50,95,100},
            new int[]{0,45,95,100},
            new int[]{0,35,95,100},
            new int[]{0,25,95,100},
            new int[]{0,10,95,100},
            new int[]{0,5,95,100},
            new int[]{0,5,95,100},
            new int[]{0,0,95,100},
            new int[]{0,0,95,100}, //Beginning
            new int[]{0,0,90,100},
            new int[]{0,5,90,100},
            new int[]{0,10,95,100},
            new int[]{0,10,95,100},
            new int[]{0,15,100,101},
            new int[]{0,20,100,101},
            new int[]{0,20,100,101},
            new int[]{0,25,100,101},
            new int[]{0,30,100,101},
            new int[]{0,35,100,101},
            new int[]{0,45,100,101},
            new int[]{30,60,100,101},
            new int[]{50,75,100,101},
            new int[]{70,80,100,101},
            new int[]{80,90,100,101},
            new int[]{85,90,100,101},
            new int[]{90,91,100,101},
            new int[]{90,101,100,101},
            new int[]{90,101,100,101},
            new int[]{93,101,100,101},
            new int[]{93,101,100,101},
            new int[]{93,101,100,101},
            new int[]{95,101,100,101},
            new int[]{95,101,100,101},
            new int[]{97,101,100,101},
            new int[]{97,101,100,101}
        };

        public static string[][][] calendar = new string[][][]
        {
            new string[][] { new string[] { "1941" }, new string[] { "January", "4","0" }, new string[] { "February", "4","0" }, new string[] { "March", "5","0" }, new string[] { "April", "4","0" }, new string[] { "May", "4","0" }, new string[] { "June", "5", "239","10" }, new string[] { "July", "4", "10","10" }, new string[] { "August", "5","10","6" }, new string[] { "September", "4","6","6" }, new string[] { "October", "4","6","4"  }, new string[] { "November", "5","4","3"  }, new string[] { "December", "4","3","6"  }},
            new string[][] { new string[] { "1942" }, new string[] { "January", "4","6","13"  }, new string[] { "February", "4","13","7"  }, new string[] { "March", "5","7","8"  }, new string[] { "April", "4","8","21"  }, new string[] { "May", "5","21","18"  }, new string[] { "June", "4","18","14"  }, new string[] { "July", "4","14","3"  }, new string[] { "August", "5","3","4"  }, new string[] { "September", "4","4","1"  }, new string[] { "October", "4","1","6"  }, new string[] { "November", "5","6","3"  }, new string[] { "December", "4","3","10"  }}, 
            new string[][] { new string[] { "1943" }, new string[] { "January", "5","10","4"  }, new string[] { "February", "4","4","3"  }, new string[] { "March", "4","3","18"  }, new string[] { "April", "4","18","0"  }, new string[] { "May", "5" ,"0" ,"3"}, new string[] { "June", "4","3" ,"2" }, new string[] { "July", "4","2","0"  }, new string[] { "August", "5","0","1"  }, new string[] { "September", "4","1","0"  }, new string[] { "October", "5","0","9"  }, new string[] { "November", "4","9","3"  }, new string[] { "December", "4","3","2"  }},
            new string[][] { new string[] { "1944" }, new string[] { "January", "5","2","1"  }, new string[] { "February", "4","1","1"  }, new string[] { "March", "4","1","8"  }, new string[] { "April", "5","8","2"  }, new string[] { "May", "4","2","0"  }, new string[] { "June", "4","0","3"  }, new string[] { "July", "5","3","13" }, new string[] { "August", "4","13","0" }, new string[] { "September", "4","0","0" }, new string[] { "October", "5","0","2" }, new string[] { "November", "4","2","1" }, new string[] { "December", "5","1","1" }},
            new string[][] { new string[] { "1945" }, new string[] { "January", "4" ,"1","17"}, new string[] { "February", "4","17","10" }, new string[] { "March", "4","10","2" }, new string[] { "April", "5","2","0" }, new string[] { "May", "4","0" }, new string[] { "June", "4","0" }, new string[] { "July", "5","0" }, new string[] { "August", "4","0" }, new string[] { "September", "5","0" }, new string[] { "October", "4" ,"0"}, new string[] { "November", "4" ,"0"}, new string[] { "December", "5" }}
        };
        
        public static int[][] unitCoords = new int[][] 
        { 
            /*
            new int[] { 16, 1690 }, new int[] { 23, 1720 }, new int[] { 28, 1750 },  new int[] { 14, 1650 }, new int[] { 40, 1780 }, new int[] { 1045, 2762 }, new int[] { 927, 2744 }, new int[] { 949, 2735 }, new int[] { 965, 2728 }, new int[] { 978, 2714 }, new int[] { 993, 2704 }, new int[] { 996, 2695 }, new int[] { 1005, 2681 }, new int[] { 1008, 2668 }, new int[] { 1033, 2692 }, new int[] { 1049, 2682 }, new int[] { 1013, 2650 }, new int[] { 1020, 2636 }, new int[] { 1044, 2628 }, new int[] { 1071, 2632 }, new int[] { 1101, 2653 }, new int[] { 1086, 2660 }, new int[] { 1133, 2653 }, new int[] { 1153, 2678 }, new int[] { 1181, 2693 }, new int[] { 1183, 2684 }, new int[] { 1168, 2711 }, new int[] { 1211, 2690 }, new int[] { 1238, 2701 }, new int[] { 1217, 2722 }, new int[] { 1242, 2746 }, new int[] { 1265, 2711 }, new int[] { 1279, 2738 }, new int[] { 1276, 2761 }, new int[] { 1268, 2788 }, new int[] { 1263, 2790 }, new int[] { 1094, 2651 }, new int[] { 1110, 2654 }, new int[] { 1128, 2658 }, new int[] { 1147, 2659 }, new int[] { 1143, 2679 }, new int[] { 1168, 2676 }, new int[] { 1188, 2678 }, new int[] { 1184, 2699 }, new int[] { 1212, 2685 }, new int[] { 1235, 2690 }, new int[] { 1225, 2707 }, new int[] { 1256, 2703 }, new int[] { 1266, 2723 }, new int[] { 1276, 2742 }, new int[] { 1282, 2759 }, new int[] { 1288, 2781 }, new int[] { 1311, 2784 }, new int[] { 1338, 2788 }, new int[] { 1336, 2771 }, new int[] { 1359, 2772 }, new int[] { 1383, 2772 }, new int[] { 1403, 2774 }, new int[] { 1423, 2773 }, new int[] { 1444, 2774 }, new int[] { 1462, 2766 }, new int[] { 1485, 2758 }, new int[] { 1480, 2784 }, new int[] { 1508, 2784 }, new int[] { 1507, 2763 }, new int[] { 1533, 2775 }, new int[] { 1526, 2756 }, new int[] { 1534, 2745 }, new int[] { 1554, 2763 }, new int[] { 1548, 2735 }, new int[] { 1562, 2729 }, new int[] { 1574, 2718 }, new int[] { 1582, 2703 }, new int[] { 1594, 2724 }, new int[] { 1596, 2690 }, new int[] { 1611, 2709 }, new int[] { 1614, 2674 }, new int[] { 1636, 2680 }, new int[] { 1659, 2687 }, new int[] { 1688, 2692 }, new int[] { 1707, 2700 }, new int[] { 1691, 2722 }, new int[] { 1728, 2698 }, new int[] { 1746, 2695 }, new int[] { 1764, 2712 }, new int[] { 1787, 2712 }, new int[] { 1787, 2734 }, new int[] { 1806, 2719 }, new int[] { 1824, 2711 }, new int[] { 1822, 2726 }, new int[] { 1843, 2709 }, new int[] { 1856, 2701 }, new int[] { 1754, 2727 }, new int[] { 1749, 2713 }, new int[] { 2281, 2728 }, new int[] { 2257, 2730 }, new int[] { 2222, 2727 }, new int[] { 2195, 2736 }, new int[] { 2171, 2751 }, new int[] { 2125, 2754 }, new int[] { 2147, 2761 }, new int[] { 2101, 2759 }, new int[] { 2107, 2764 }, new int[] { 2053, 2755 }, new int[] { 2069, 2754 }, new int[] { 2087, 2766 }, new int[] { 2039, 2755 }, new int[] { 2020, 2754 }, new int[] { 2002, 2758 }, new int[] { 2039, 2769 }, new int[] { 1979, 2756 }, new int[] { 1860, 2737 }, new int[] { 1878, 2723 }, new int[] { 1897, 2719 }, new int[] { 1916, 2710 }, new int[] { 1937, 2711 }, new int[] { 1954, 2722 }, new int[] { 1959, 2746 }, new int[] { 1959, 2760 }, new int[] { 1941, 2734 }, new int[] { 1862, 2719 }, new int[] { 2088, 2790 }, new int[] { 2086, 2790 }, new int[] { 2314, 2738 }, new int[] { 2338, 2719 }, new int[] { 2366, 2700 }, new int[] { 2406, 2670 }, new int[] { 2422, 2650 }, new int[] { 2442, 2620 }, new int[] { 2473, 2596 }, new int[] { 2498, 2566 }, new int[] { 2526, 2543 }, new int[] { 2556, 2521 }, new int[] { 2586, 2514 }, new int[] { 2610, 2499 }, new int[] { 2635, 2494 }, new int[] { 2676, 2485 }, new int[] { 2709, 2469 }, new int[] { 2755, 2461 }, new int[] { 2797, 2449 }, new int[] { 2833, 2439 }, new int[] { 2869, 2443 }, new int[] { 2912, 2448 }, new int[] { 2961, 2455 }, new int[] { 2993, 2459 }, new int[] { 3030, 2468 }, new int[] { 58, 1650 }, new int[] { 575, 2000 }, new int[] { 67, 1735 }, new int[] { 225, 1685 }, new int[] { 74, 1775 }, new int[] { 901, 2728 }, new int[] { 675, 2500}, new int[] { 978, 2670 }, new int[] { 1007, 2622 }, new int[] { 1055, 2599 }, new int[] { 1098, 2618 }, new int[] { 756, 2635 }, new int[] { 849, 2515 }, new int[] { 1009, 2476 }, new int[] { 1149, 2633 }, new int[] { 1200, 2643 }, new int[] { 1251, 2555 }, new int[] { 1281, 2668 }, new int[] { 1307, 2688 }, new int[] { 1330, 2726 }, new int[] { 1366, 2727 }, new int[] { 1425, 2724 }, new int[] { 1462, 2716 }, new int[] { 1508, 2701 }, new int[] { 1558, 2680 }, new int[] { 1165, 2496 }, new int[] { 1375, 2200 }, new int[] { 1306, 2275 }, new int[] { 1400, 2400 }, new int[] { 1424, 2147 }, new int[] { 1494, 2544 }, new int[] { 1578, 2546 }, new int[] { 1400, 2533 }, new int[] { 1610, 2646 }, new int[] { 1669, 2663 }, new int[] { 1900, 2575 }, new int[] { 1821, 2674 }, new int[] {  3032, 2206   }, new int[] { 2100, 2250 }, new int[] { 1733, 2500 }, new int[] { 2183, 2625 }, new int[] { 2625, 2425 }, new int[] { 2500, 2393 }, new int[] { 2390, 2540 }, new int[] { 2425, 2512 }, new int[] { 2760, 2386 }, new int[] { 2000, 2500 }, new int[] { 2000, 2438 }, new int[] { 1733, 2424 }, new int[] { 2050, 2550 }, new int[] { 2753, 2393 }, new int[] { 2823, 2368 }, new int[] { 2879, 2364 }, new int[] { 2928, 2339 }, new int[] { 2066, 2666 }, new int[] { 3025, 2262 }, new int[] {  2375, 2400}, new int[] { 2960, 2124 }, new int[] { 2200, 2500 }, new int[] { 2300, 2500 }, new int[] { 2000, 2326 }, new int[] { 2100, 2352 }, new int[] { 2175, 2288 }, new int[] { 2350, 2288 }, new int[] { 1174, 1112 }, new int[] { 1174, 1112 }, new int[] { 1182, 1087 }, new int[] { 1179, 984 }, new int[] { 1197, 1000 }, new int[] { 1412, 1275 }, new int[] { 1335, 1152 }, new int[] { 1354, 1167 }, new int[] { 930, 1259 }, new int[] { 934, 1288 }, new int[] { 1029, 1457 }, new int[] { 1054, 1459 }, new int[] { 1610, 1503 }, new int[] { 1631, 1527 }, new int[] { 1286, 1689 }, new int[] { 1294, 1721 }, new int[] { 1064, 1174 }, new int[] { 1140, 1254 }, new int[] { 1226, 1250 }, new int[] { 1273, 1222 }, new int[] { 1169, 1100 }, new int[] { 3600, 608 }, new int[] { 3600, 608 }, new int[] { 3408, 873 }, new int[] { 3479, 1008 }, new int[] { 3880, 449 }, new int[] { 2630, 2200 }, new int[] { 3824, 876 }, new int[] { 3270, 980 }
             */
            new int[] {8,650},new int[] {11,662},new int[] {13,673},new int[] {7,635},new int[] {19,685},new int[] {498,1062},new int[] {441,1055},new int[] {452,1052},new int[] {460,1049},new int[] {466,1044},new int[] {473,1040},new int[] {474,1037},new int[] {479,1031},new int[] {480,1026},new int[] {492,1035},new int[] {500,1032},new int[] {482,1019},new int[] {486,1014},new int[] {497,1011},new int[] {510,1012},new int[] {524,1020},new int[] {517,1023},new int[] {540,1020},new int[] {549,1030},new int[] {562,1036},new int[] {563,1032},new int[] {556,1043},new int[] {577,1035},new int[] {590,1039},new int[] {580,1047},new int[] {591,1056},new int[] {602,1043},new int[] {609,1053},new int[] {608,1062},new int[] {604,1072},new int[] {601,1073},new int[] {521,1020},new int[] {529,1021},new int[] {537,1022},new int[] {546,1023},new int[] {544,1030},new int[] {556,1029},new int[] {566,1030},new int[] {564,1038},new int[] {577,1033},new int[] {588,1035},new int[] {583,1041},new int[] {598,1040},new int[] {603,1047},new int[] {608,1055},new int[] {610,1061},new int[] {613,1070},new int[] {624,1071},new int[] {637,1072},new int[] {636,1066},new int[] {647,1066},new int[] {659,1066},new int[] {668,1067},new int[] {678,1067},new int[] {688,1067},new int[] {696,1064},new int[] {707,1061},new int[] {705,1071},new int[] {718,1071},new int[] {718,1063},new int[] {730,1067},new int[] {727,1060},new int[] {730,1056},new int[] {740,1063},new int[] {737,1052},new int[] {744,1050},new int[] {750,1045},new int[] {753,1040},new int[] {759,1048},new int[] {760,1035},new int[] {767,1042},new int[] {769,1028},new int[] {779,1031},new int[] {790,1033},new int[] {804,1035},new int[] {813,1038},new int[] {805,1047},new int[] {823,1038},new int[] {831,1037},new int[] {840,1043},new int[] {851,1043},new int[] {851,1052},new int[] {860,1046},new int[] {869,1043},new int[] {868,1048},new int[] {878,1042},new int[] {884,1039},new int[] {835,1049},new int[] {833,1043},new int[] {1086,1049},new int[] {1075,1050},new int[] {1058,1049},new int[] {1045,1052},new int[] {1034,1058},new int[] {1012,1059},new int[] {1022,1062},new int[] {1000,1061},new int[] {1003,1063},new int[] {978,1060},new int[] {985,1059},new int[] {994,1064},new int[] {971,1060},new int[] {962,1059},new int[] {953,1061},new int[] {971,1065},new int[] {942,1060},new int[] {886,1053},new int[] {894,1047},new int[] {903,1046},new int[] {912,1042},new int[] {922,1043},new int[] {930,1047},new int[] {933,1056},new int[] {933,1062},new int[] {924,1052},new int[] {887,1046},new int[] {994,1073},new int[] {993,1073},new int[] {1102,1053},new int[] {1113,1046},new int[] {1127,1038},new int[] {1146,1027},new int[] {1153,1019},new int[] {1163,1008},new int[] {1178,998},new int[] {1190,987},new int[] {1203,978},new int[] {1217,970},new int[] {1231,967},new int[] {1243,961},new int[] {1255,959},new int[] {1274,956},new int[] {1290,950},new int[] {1312,947},new int[] {1332,942},new int[] {1349,938},new int[] {1366,940},new int[] {1387,942},new int[] {1410,944},new int[] {1425,946},new int[] {1443,949},new int[] {28,635},new int[] {274,769},new int[] {32,667},new int[] {107,648},new int[] {35,683},new int[] {429,1049},new int[] {321,962},new int[] {466,1027},new int[] {480,1008},new int[] {502,1000},new int[] {523,1007},new int[] {360,1013},new int[] {404,967},new int[] {480,952},new int[] {547,1013},new int[] {571,1017},new int[] {596,983},new int[] {610,1026},new int[] {622,1034},new int[] {633,1048},new int[] {650,1049},new int[] {679,1048},new int[] {696,1045},new int[] {718,1039},new int[] {742,1031},new int[] {555,960},new int[] {655,846},new int[] {622,875},new int[] {667,923},new int[] {678,826},new int[] {711,978},new int[] {751,979},new int[] {667,974},new int[] {767,1018},new int[] {795,1024},new int[] {905,990},new int[] {867,1028},new int[] {1444,848},new int[] {1000,865},new int[] {825,962},new int[] {1040,1010},new int[] {1250,933},new int[] {1190,920},new int[] {1138,977},new int[] {1155,966},new int[] {1314,918},new int[] {952,962},new int[] {952,938},new int[] {825,932},new int[] {976,981},new int[] {1311,920},new int[] {1344,911},new int[] {1371,909},new int[] {1394,900},new int[] {984,1025},new int[] {1440,870},new int[] {1131,923},new int[] {1410,817},new int[] {1048,962},new int[] {1095,962},new int[] {952,895},new int[] {1000,905},new int[] {1036,880},new int[] {1119,880},new int[] {559,428},new int[] {559,428},new int[] {563,418},new int[] {561,378},new int[] {570,385},new int[] {672,490},new int[] {636,443},new int[] {645,449},new int[] {443,484},new int[] {445,495},new int[] {490,560},new int[] {502,561},new int[] {767,578},new int[] {777,587},new int[] {612,650},new int[] {616,662},new int[] {507,452},new int[] {543,482},new int[] {584,481},new int[] {606,470},new int[] {557,423},new int[] {1714,234},new int[] {1714,234},new int[] {1623,336},new int[] {1657,388},new int[] {1848,173},new int[] {1252,846},new int[] {1821,337},new int[] {1557,377},
        };

        //{X,Y,Points,Side,Moscow/L'grad/Bucharesti/Helsinki}        
        public static int[][] cityCoords = new int[][] 
        { 
             new int[] { 1181, 1079, 2, 1, 2 }, new int[] { 1177, 965, 2, 1, 91 }, new int[] { 1182, 1018, 1, 1, 92 }, new int[] { 478, 818, 2, 1, 93 }, new int[] { 1108, 455, 2, 1, 94 }, new int[] { 1097, 479, 2, 1, 95 }, new int[] { 1089, 718, 2, 1, 96 }, new int[] { 990, 712, 2, 1, 97 }, new int[] { 793, 736, 2, 1, 98 }, new int[] { 944, 746, 2, 1, 99 }, new int[] { 714, 939, 2, 1, 910 }, new int[] { 821, 851, 2, 1, 911 }, new int[] { 1130, 807, 2, 1, 912 }, new int[] { 1206, 1097, 2, 1, 2 }, new int[] { 1174, 1114, 2, 1, 2 }, new int[] { 1352, 1130, 1, 1, 915 }, new int[] { 929, 1245, 2, 1, 916 }, new int[] { 785, 1360, 2, 1, 917 }, new int[] { 1035, 1421, 2, 1, 918 }, new int[] { 203, 1671, 2, 1, 1 }, new int[] { 233, 1676, 2, 1, 1 }, new int[] { 1287, 1685, 2, 1, 921 }, new int[] { 532, 1661, 2, 1, 922 }, new int[] { 594, 1951, 2, 1, 923 }, new int[] { 1177, 1863, 2, 1, 924 }, new int[] { 23, 1768, 2, 0, 925 }, new int[] { 39, 2135, 2, 0, 10 }, new int[] { 187, 2200, 2, 1, 927 }, new int[] { 433, 2074, 2, 1, 928 }, new int[] { 658, 2375, 2, 1, 929 }, new int[] { 713, 2434, 2, 1, 930 }, new int[] { 938, 2185, 2, 1, 931 }, new int[] { 1361, 2166, 2, 1, 932 }, new int[] { 659, 2708, 2, 1, 933 }, new int[] { 823, 2728, 2, 1, 934 }, new int[] { 1052, 2728, 2, 0, 935 }, new int[] { 1061, 2498, 2, 1, 936 }, new int[] { 1142, 2375, 2, 1, 937 }, new int[] { 1379, 2665, 2, 1, 938 }, new int[] { 2120, 2206, 2, 1, 939 }, new int[] { 2194, 2232, 2, 1, 940 }, new int[] { 2234, 2432, 2, 1, 941 }, new int[] { 1986, 2465, 2, 1, 942 }, new int[] { 1721, 1869, 2, 1, 943 }, new int[] { 2134, 1999, 2, 1, 944 }, new int[] { 2167, 2592, 2, 1, 945 }, new int[] { 2454, 2096, 2, 1, 946 }, new int[] { 2261, 2057, 1, 1, 947 }, new int[] { 2412, 2548, 1, 1, 948 }, new int[] { 2383, 2507, 2, 1, 949 }, new int[] { 2577, 2542, 1, 0, 950 }, new int[] { 2515, 2633, 1, 0, 951 }, new int[] { 2348, 2690, 2, 1, 952 }, new int[] { 2268, 2713, 1, 0, 953 }, new int[] { 2791, 2315, 2, 1, 954 }, new int[] { 2852, 2266, 1, 1, 955 }, new int[] { 2724, 2468, 2, 0, 956 }, new int[] { 2339, 2266, 2, 1, 957 }, new int[] { 2041, 2753, 2, 1, 958 }, new int[] { 3219, 2759, 2, 0, 20 }, new int[] { 3129, 2761, 2, 0, 960 }, new int[] { 2997, 2567, 1, 1, 961 }, new int[] { 3113, 2484, 2, 0, 962 }, new int[] { 3076, 2478, 2, 0, 963 }, new int[] { 3120, 2378, 1, 0, 964 }, new int[] { 2925, 2501, 1, 0, 965 }, new int[] { 3342, 2454, 2, 0, 966 }, new int[] { 2984, 2183, 1, 1, 967 }, new int[] { 2940, 2113, 2, 1, 968 }, new int[] { 2967, 2781, 1, 0, 969 }, new int[] { 2935, 2750, 1, 0, 970 }, new int[] { 3531, 2595, 2, 0, 971 }, new int[] { 3389, 1810, 2, 1, 972 }, new int[] { 3268, 1822, 1, 1, 973 }, new int[] { 3341, 1730, 2, 1, 974 }, new int[] { 3428, 1736, 2, 1, 975 }, new int[] { 3337, 1586, 2, 1, 976 }, new int[] { 2960, 1873, 2, 1, 977 }, new int[] { 2871, 1932, 2, 1, 978 }, new int[] { 2466, 1708, 2, 1, 979 }, new int[] { 2569, 1859, 2, 1, 980 }, new int[] { 2712, 1751, 1, 1, 981 }, new int[] { 2384, 1853, 2, 1, 982 }, new int[] { 3291, 1431, 2, 1, 983 }, new int[] { 3446, 1297, 2, 1, 984 }, new int[] { 2772, 1535, 2, 1, 985 }, new int[] { 2623, 1537, 2, 1, 986 }, new int[] { 2973, 1539, 2, 1, 987 }, new int[] { 3002, 1361, 2, 1, 988 }, new int[] { 2953, 1275, 2, 1, 989 }, new int[] { 3065, 1208, 2, 1, 990 }, new int[] { 2777, 1210, 2, 1, 991 }, new int[] { 3396, 1112, 2, 1, 992 }, new int[] { 2685, 1209, 2, 1, 993 }, new int[] { 2658, 1176, 2, 1, 994 }, new int[] { 2578, 1225, 2, 1, 995 }, new int[] { 2332, 1349, 2, 1, 996 }, new int[] { 2372, 1573, 2, 1, 997 }, new int[] { 2251, 1497, 2, 1, 998 }, new int[] { 2117, 1513, 2, 1, 999 }, new int[] { 1968, 1333, 2, 1, 9100 }, new int[] { 1703, 1323, 2, 1, 9101 }, new int[] { 1637, 1494, 2, 1, 9102 }, new int[] { 2133, 1652, 2, 1, 9103 }, new int[] { 2038, 1683, 2, 1, 9104 }, new int[] { 2145, 1775, 2, 1, 9105 }, new int[] { 1937, 1880, 2, 1, 9106 }, new int[] { 2034, 1835, 2, 1, 9107 }, new int[] { 2069, 1865, 1, 1, 9108 }, new int[] { 2207, 1307, 1, 1, 9109 }, new int[] { 1431, 1886, 2, 1, 9110 }, new int[] { 1409, 1251, 2, 1, 9111 }, new int[] { 1492, 1127, 2, 1, 9112 }, new int[] { 1466, 1624, 2, 1, 9113 }, new int[] { 2017, 1003, 2, 1, 9114 }, new int[] { 1768, 846, 2, 1, 9115 }, new int[] { 1816, 736, 2, 1, 9116 }, new int[] { 1833, 692, 1, 1, 9117 }, new int[] { 1830, 606, 1, 1, 9118 }, new int[] { 1669, 702, 1, 1, 9119 }, new int[] { 1418, 892, 2, 1, 9120 }, new int[] { 1343, 999, 1, 1, 9121 }, new int[] { 1286, 959, 1, 1, 9122 }, new int[] { 2943, 1096, 2, 1, 9123 }, new int[] { 2955, 1012, 2, 1, 9124 }, new int[] { 2938, 983, 2, 1, 9125 }, new int[] { 2906, 944, 1, 1, 9126 }, new int[] { 2677, 1034, 2, 1, 9127 }, new int[] { 2105, 681, 2, 1, 9128 }, new int[] { 2216, 860, 1, 1, 9129 }, new int[] { 3490, 980, 2, 1, 9130 }, new int[] { 3471, 906, 1, 1, 9131 }, new int[] { 3423, 846, 2, 1, 9132 }, new int[] { 3408, 736, 2, 1, 9133 }, new int[] { 3690, 997, 1, 1, 9134 }, new int[] { 3825, 871, 1, 1, 9135 }, new int[] { 3660, 641, 1, 1, 9136 }, new int[] { 3605, 604, 2, 1, 9137 }, new int[] { 3755, 261, 2, 1, 9138 }, new int[] { 2659, 410, 2, 1, 9139 }, new int[] { 1732, 197, 2, 1, 9140 }, new int[] { 1721, 347, 2, 1, 9141 }, new int[] { 2079, 253, 2, 1, 9142 }, new int[] { 2094, 223, 2, 1, 9143 }, new int[] { 1507, 23, 2, 1, 9144 }, new int[] { 1954, 101, 2, 1, 9145 }, new int[] { 1808, 1057, 2, 1, 9146 }, new int[] { 1597, 2654, 1, 1, 9147 }, new int[] { 1302, 2552, 1, 1, 9148 }, new int[] { 971, 2699, 1, 0, 9149 }, new int[] { 2427, 2610, 1, 1, 9150 }, new int[] { 1554, 2028, 1, 1, 9151 }, new int[] { 273, 1888, 1, 1, 9152 }
        };
    }

    public static class round
    {
        //week of month, week of year, side,last unit, starting turn, changed side         
        public static int[] turn = { 4, 24, 0, -1, 24,0};
        public static Unit lastMoved=null;
        
        //Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][1]))

        //Year, Month, # of Units arriving, # of units on board (cumulative)
        public static int[] currentCalendar = { 0, 6, 239, 0 };

        //3 zones: Baltic,Russian, Ukranian
        public static string[] currentWeather = {"Calm","Calm","Calm"}; //i.e. Rain
        public static string[] currentGround = { "Clear", "Clear", "Clear" };  //i.e. Mud    
        

        public static bool[] invasions = { false, false, true };
        public static bool[] moscowTaken = { false, false };
        public static double[] points = { 0, 0 };
        public static int[] mapCoords = { 0, 0 };

        //change size of terrain and map
        public static System.Drawing.Bitmap terrain = new System.Drawing.Bitmap(global::Barbarossa.Properties.Resources.Terrain);

        //Check phyiscal size of screen (for TV vs. Computer)
        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]//, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true
        //public static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        //Make available for Game and Unit cs
        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public const int HORZSIZE = 4;
        public const int VERTSIZE = 6;
        public const double MM_TO_INCH_CONVERSION_FACTOR = 25.4;
        /*
        var hDC = Graphics.FromHwnd(this.Handle).GetHdc();
        public static int horizontalSizeInMilliMeters = GetDeviceCaps(hDC, HORZSIZE);
        public static double horizontalSizeInInches = horizontalSizeInMilliMeters / MM_TO_INCH_CONVERSION_FACTOR;
        public static int verticalSizeInMilliMeters = GetDeviceCaps(hDC, VERTSIZE);
        public static double verticalSizeInInches = verticalSizeInMilliMeters / MM_TO_INCH_CONVERSION_FACTOR;
        //physicalX=horizontalSizeInInches/1920;
        //physicalY = verticalSizeInInches / 1080;
        public static double physicalX = horizontalSizeInInches / 26.6;
        public static double physicalY = verticalSizeInInches / 15;
        public static double physicalDelta = Math.Sqrt((physicalX * physicalX) + (physicalY * physicalY));
        */
    }
}
