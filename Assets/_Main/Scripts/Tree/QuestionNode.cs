namespace _Main.Scripts.Tree
{
    public class QuestionNode : INode
    {
        public delegate bool myDelegate();
        myDelegate _question;
        INode _trueNode;
        INode _falseNode;
        public QuestionNode(myDelegate question, INode tN, INode fN)
        {
            _question = question;
            _trueNode = tN;
            _falseNode = fN;
        }
        public void Execute()
        {
            if (_question())
            {
                //True
                _trueNode.Execute();
            }
            else
            {
                //False
                _falseNode.Execute();
            }
        }
    }
}
