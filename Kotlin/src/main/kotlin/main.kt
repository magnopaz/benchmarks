import kotlin.system.measureTimeMillis

fun main(args: Array<String>) {
    val n = 10000000;
    var list : MutableList<Int> = ArrayList()

    for (i in 1..n)
    {
        list.add(i)
    }

    val resultFor = measureTimeMillis{
        for (i in 1..n)
        {
            isPrime(i)
        }
    }

    val resultForEach = measureTimeMillis{
        list.forEach{
            isPrime(it)
        }
    }

    val totalTime = "Time in milliseconds: $resultFor Method: for\n Time in milliseconds: $resultForEach Method: foreach";
    print(totalTime)
}

fun isPrime(num: Int): Boolean {
    if (num == 2) return true
    if (num <= 1 || num % 2 == 0) return false
    val sqrtNum: Double = kotlin.math.sqrt(num.toDouble())
    var div = 3
    while (div <= sqrtNum) {
        if (num % div == 0) return false
        div += 2
    }
    return true
}