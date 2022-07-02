namespace Calculator.Test
{
    public class CalculatorModelTests
    {
        BaseCalculatorModel _calculator = new();

        ParameterizedOperationExecuting parameterized = new();

        OperationExecuting notParameterized = new();

        [Fact]
        public void Sum_SimpleValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "517";

            parameterized.SetOperation(new Numbers(_calculator)).Do("362");
            parameterized.SetOperation(new Sign(_calculator)).Do("+");
            parameterized.SetOperation(new Numbers(_calculator)).Do("155");

            //Act
            var actual = notParameterized.SetOperation(new Equally(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Subtraction_SimpleValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "207";

            parameterized.SetOperation(new Numbers(_calculator)).Do("362");
            parameterized.SetOperation(new Sign(_calculator)).Do("-");
            parameterized.SetOperation(new Numbers(_calculator)).Do("155");

            //Act
            var actual = notParameterized.SetOperation(new Equally(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Multiplication_SimpleValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "56110";

            parameterized.SetOperation(new Numbers(_calculator)).Do("155");
            parameterized.SetOperation(new Sign(_calculator)).Do("*");
            parameterized.SetOperation(new Numbers(_calculator)).Do("362");

            //Act
            var actual = notParameterized.SetOperation(new Equally(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Division_SimpleValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "0,4281767955801105";

            parameterized.SetOperation(new Numbers(_calculator)).Do("155");
            parameterized.SetOperation(new Sign(_calculator)).Do("/");
            parameterized.SetOperation(new Numbers(_calculator)).Do("362");

            //Act
            var actual = notParameterized.SetOperation(new Equally(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Power_SimpleValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "89466096875";

            parameterized.SetOperation(new Numbers(_calculator)).Do("155");
            parameterized.SetOperation(new Sign(_calculator)).Do("^");
            parameterized.SetOperation(new Numbers(_calculator)).Do("5");

            //Act
            var actual = notParameterized.SetOperation(new Equally(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SquareRoot_SimpleValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "19,026297590440446";

            parameterized.SetOperation(new UnaryElements(_calculator)).Do("362");
            parameterized.SetOperation(new UnaryElements(_calculator)).Do("√");

            //Act
            var actual = notParameterized.SetOperation(new Equally(_calculator)).Realize();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Fraction_SimpleValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "0,0027624309392265192";

            parameterized.SetOperation(new UnaryElements(_calculator)).Do("362");
            parameterized.SetOperation(new UnaryElements(_calculator)).Do("|");

            //Act
            var actual = notParameterized.SetOperation(new Equally(_calculator)).Realize();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SignChange_SimpleValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "-362";

            parameterized.SetOperation(new UnaryElements(_calculator)).Do("362");
            parameterized.SetOperation(new UnaryElements(_calculator)).Do("±");

            //Act
            var actual = notParameterized.SetOperation(new Equally(_calculator)).Realize();

            //Assert
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void Sum_ComplexValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "544";

            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("35");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("+");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("225");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("+");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("65");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("+");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("97");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("+");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("122");

            //Act
            notParameterized.SetOperation(new AdvancedEqually(_calculator)).Realize();
            var actual = notParameterized.SetOperation(new AdvancedEqually(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Subtraction_ComplexValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "-474";

            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("35");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("-");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("225");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("-");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("65");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("-");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("97");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("-");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("122");

            //Act
            notParameterized.SetOperation(new AdvancedEqually(_calculator)).Realize();
            var actual = notParameterized.SetOperation(new AdvancedEqually(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Multiplication_ComplexValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "10800";

            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("3");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("*");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("25");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("*");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("6");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("*");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("2");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("*");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("12");

            //Act
            notParameterized.SetOperation(new AdvancedEqually(_calculator)).Realize();
            var actual = notParameterized.SetOperation(new AdvancedEqually(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Division_ComplexValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "1,5034364261168385";

            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("3500");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("/");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("2");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("/");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("6");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("/");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("97");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("/");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("2");

            //Act
            notParameterized.SetOperation(new AdvancedEqually(_calculator)).Realize();
            var actual = notParameterized.SetOperation(new AdvancedEqually(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Power_ComplexValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "59049";

            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("3");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("^");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("2");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("^");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("5");


            //Act
            notParameterized.SetOperation(new AdvancedEqually(_calculator)).Realize();
            var actual = notParameterized.SetOperation(new AdvancedEqually(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }   

        [Fact]
        public void Сombined1_ComplexValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "3395";

            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("35");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("*");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("(");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("72");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("+");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("49");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("-");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("24");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do(")");

            //Act
            notParameterized.SetOperation(new AdvancedEqually(_calculator)).Realize();
            var actual = notParameterized.SetOperation(new AdvancedEqually(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Сombined2_ComplexValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "3863";

            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("35");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("*");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("(");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("72");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("+");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("49");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("-");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("24");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do(")");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("+");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("522");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("-");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("47");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("-");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("(");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("49");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("/");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("7");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do(")");


            //Act
            notParameterized.SetOperation(new AdvancedEqually(_calculator)).Realize();
            var actual = notParameterized.SetOperation(new AdvancedEqually(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Сombined3_ComplexValue_ShouldBeCalculated()
        {
            //Arrage
            var expected = "2108,0408163265306";

            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("3");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("*");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("(");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("720");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("+");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("49");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("-");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("240");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do(")");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("+");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("522");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("-");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("47");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("/");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("(");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("49");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("/");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("7");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do(")");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("^");
            parameterized.SetOperation(new AdvancedElements(_calculator)).Do("2");


            //Act
            notParameterized.SetOperation(new AdvancedEqually(_calculator)).Realize();
            var actual = notParameterized.SetOperation(new AdvancedEqually(_calculator)).Do();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}