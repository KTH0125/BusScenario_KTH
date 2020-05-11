using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SummaryData {
	public int index,taskNum,subTaskNum,answerBus,problemBus,select,targetbus;

	public float time;
	public float moveDistance;
	public int ommition,commition;
	public int additionalProblem;

	public SummaryData(int index,int taskNum,int subTaskNum, int answerBus, int problemBus, int select,int targetbus,float time, float moveDistance,int ommition,int commition, int additionalProblem){
		this.index=index;
		this.taskNum=taskNum;
		this.subTaskNum=subTaskNum;
		this.answerBus=answerBus;
		this.problemBus=problemBus;
		this.select=select;
		this.time=time;
		this.moveDistance=moveDistance;
		this.ommition=ommition;
		this.commition=commition;
		this.targetbus=targetbus;

		this.additionalProblem=additionalProblem;
	}
	public void Write(StreamWriter sw){
		sw.WriteLine(index+","+taskNum+","+subTaskNum+","+answerBus+","+problemBus+","+select+","+targetbus+","+time+","+moveDistance+","+ommition+","+commition+","+additionalProblem);
	}
}
