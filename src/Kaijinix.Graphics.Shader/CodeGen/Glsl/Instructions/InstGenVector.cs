using Kaijinix.Graphics.Shader.IntermediateRepresentation;
using Kaijinix.Graphics.Shader.StructuredIr;

using static Kaijinix.Graphics.Shader.CodeGen.Glsl.Instructions.InstGenHelper;
using static Kaijinix.Graphics.Shader.StructuredIr.InstructionInfo;

namespace Kaijinix.Graphics.Shader.CodeGen.Glsl.Instructions
{
    static class InstGenVector
    {
        public static string VectorExtract(CodeGenContext context, AstOperation operation)
        {
            IAstNode vector = operation.GetSource(0);
            IAstNode index = operation.GetSource(1);

            string vectorExpr = GetSourceExpr(context, vector, OperandManager.GetNodeDestType(context, vector));

            if (index is AstOperand indexOperand && indexOperand.Type == OperandType.Constant)
            {
                char elem = "xyzw"[indexOperand.Value];

                return $"{vectorExpr}.{elem}";
            }
            else
            {
                string indexExpr = GetSourceExpr(context, index, GetSrcVarType(operation.Inst, 1));

                return $"{vectorExpr}[{indexExpr}]";
            }
        }
    }
}
