using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class UserData {

	public int index,taskNum,subTaskNum,answerBus,problemBus,select;
	
	public Vector3 pos,rot;
	public float time,distance;
	public UserData(int index,int taskNum, int subTaskNum, int answerBus, int problemBus, int select, Vector3 pos, Vector3 rot,float time,float distance){
		this.index=index;
		this.taskNum=taskNum;
		this.subTaskNum=subTaskNum;
		this.answerBus=answerBus;
		this.problemBus=problemBus;
		this.select=select;
		this.pos=pos;
		this.rot=rot;
		this.time=time;
		this.distance=distance;
	}
	public void Write(StreamWriter sw){
		sw.WriteLine(index+","+taskNum+","+subTaskNum+","+answerBus+","+problemBus+","+select+","+pos.x+","+pos.y+","+pos.z+","+rot.x+","+rot.y+","+rot.z+","+time+","+distance);
	}
}
