# Language Grammar
The following is the active pseudo-grammar of the bicep language.
```
program -> statement* EOF 
statement -> 
  parameterDecl | 
  variableDecl |
  resourceDecl |
  outputDecl |
  NL

parameterDecl -> "parameter" IDENTIFIER(name) IDENTIFIER(type) (parameterDefaultValue | object(modifier))? NL
parameterDefaultValue -> "=" expression

variableDecl -> "variable" IDENTIFIER(name) "=" expression NL

resourceDecl -> "resource" IDENTIFIER(name) interpString(type) "=" object NL

outputDecl -> "output" IDENTIFIER(name) IDENTIFIER(type) "=" expression NL

NL -> ("\n" | "\r")+

expression -> 
  binaryExpression |
  binaryExpression "?" expression ":" expression

binaryExpression -> 
  equalityExpression |
  binaryExpression "&&" equalityExpression |
  binaryExpression "||" equalityExpression |
  binaryExpression "??" equalityExpression

equalityExpression -> 
  relationalExpression |
  equalityExpression "==" relationalExpression |
  equalityExpression "!=" relationalExpression

relationalExpression -> 
  additiveExpression |
  relationalExpression ">" additiveExpression |
  relationalExpression ">=" additiveExpression |
  relationalExpression "<" additiveExpression |
  relationalExpression "<=" additiveExpression

additiveExpression -> 
  multiplicativeExpression |
  additiveExpression "+" multiplicativeExpression |
  additiveExpression "-" multiplicativeExpression

multiplicativeExpression -> 
  unaryExpression |
  multiplicativeExpression "*" unaryExpression |
  multiplicativeExpression "/" unaryExpression |
  multiplicativeExpression "%" unaryExpression

unaryExpression ->
  memberExpression |
  unaryOperator unaryExpression

unaryOperator -> "!" | "-" | "+"

memberExpression ->
  primaryExpression |
  memberExpression "[" expression "]" |
  memberExpression "." IDENTIFIER(property)

primaryExpression ->
  functionCall |
  literalValue |
  interpString |
  array |
  object |
  parenthesizedExpression

functionCall -> IDENTIFIER "(" argumentList? ")"

argumentList -> expression ("," expression)*

parenthesizedExpression -> "(" expression ")"

interpString ->  interpStringLeftPiece ( expression interpStringMiddlePiece )* expression interpStringRightPiece | literalString
interpStringLeftPiece -> "'" STRINGCHAR* "${"
interpStringMiddlePiece -> "}" STRINGCHAR* "${"
interpStringRightPiece -> "}" STRINGCHAR* "'"
literalString -> "'" STRINGCHAR* "'"

literalValue -> NUMBER | "true" | "false" | "null"

object -> "{" ( NL+ ( objectProperty NL+ )* )? "}"
objectProperty -> ( IDENTIFIER(name) | literalString ) ":" expression 

array -> "[" ( NL+ arrayItem* )? "]"
arrayItem -> expression NL+

```