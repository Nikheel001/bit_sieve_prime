# For timing the durations
import timeit

# Historical data for validating our results - the LIMITber of primes
# to be found under some limit, such as 168 primes under 1000
primeCounts = {10: 1, 100: 25, 1000: 168, 10000: 1229, 100000: 9592,
               1000000: 78498, 10000000: 664579, 100000000: 5761455}

LIMIT = None

#for faster index access use numpy.array (library installation required) or array.array or dict
arr = None

def runSieve():
    global arr, LIMIT

    # reset
    LIMIT = 1000000
    arr = [True] * (LIMIT >> 1)
    END = int(LIMIT**0.5)

    # start again
    # for every odd digit
    for i in range(3, END, 2):
        if arr[i >> 1]:
            i2 = i << 1
            for j in range(i+i2, LIMIT, i2):
                arr[j >> 1] = False


def printResults(showResults, duration, passes):
    global arr, LIMIT

    # Count (and optionally dump) the primes that were found below the limit
    if showResults:
        print(2, end=',')
        [print(i, end=',') for i in range(3, LIMIT, 2) if arr[i >> 1]]

    count = sum(1 for i in arr if i)

    count2 = primeCounts.get(LIMIT, 0)
    assert(count == count2)

    #
    print()
    print("Passes:", passes, ", Time:", duration, ", Avg:", duration/passes,
          ", Limit:", LIMIT, ", Count:", count, ", Valid:", count2 == count)


# Record our starting time
tStart = timeit.default_timer()

# We're going to count how many passes we make in fixed window of time
passes = 0

# Run until more than 10 seconds have elapsed
while (timeit.default_timer() - tStart < 10):
    # reset and start again
    runSieve()

    #  Count this pass
    passes = passes + 1

# After the "at least 10 seconds", get the actual elapsed
tD = timeit.default_timer() - tStart

# Display outcome
printResults(False, tD, passes)
