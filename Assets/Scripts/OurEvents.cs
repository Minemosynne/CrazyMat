using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

namespace Our.Events {
	[System.Serializable]
	public class ObjectEvent : UnityEvent<GameObject>{}
}
