
using System.Collections.Generic;
public enum BTState
{
    Failure,
    Success,
    Running
}
public abstract class BTNode 
{
    
    protected List<BTNode> children = new List<BTNode>();

    public void AddChild(BTNode node)
    {
        children.Add(node);
    }

    public virtual BTState Evaluate()
    {
        return BTState.Running;
    }
}

public class BTActtion : BTNode
{
    private System.Func<BTState> action;

    public BTActtion(System.Func<BTState> action)
    {
        this.action = action;
    }

    public override BTState Evaluate()
    {
        return action();
    }
}

public class BTSequence : BTNode
{
    public override BTState Evaluate()
    {
        bool isAnyChildRunning = false;

        foreach (BTNode node in children)
        {
            BTState result = node.Evaluate();
            if (result == BTState.Failure)
            {
                return BTState.Failure;
            }
            else if (result == BTState.Running)
            {
                isAnyChildRunning = true;
            }
        }
        return isAnyChildRunning ? BTState.Running : BTState.Success;
    }
}

public class BTSelector : BTNode
{
    public override BTState Evaluate()
    {
        foreach (BTNode node in children)
        {
            BTState result = node.Evaluate();
            if (result == BTState.Success)
            {
                return BTState.Success;
            }
            else if (result == BTState.Running)
            {
                return BTState.Running;
            }
        }
        return BTState.Failure;
    }
}

public class BTCondition : BTNode
{
    private System.Func<bool> condition;

    public BTCondition(System.Func<bool> condition)
    {
        this.condition = condition;
    }
    public override BTState Evaluate()
    {
        return condition() ? BTState.Success : BTState.Failure;
    }
}

