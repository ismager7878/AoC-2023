using System.Data;
using System.IO.Compression;

class Corresponder{
    public long offSet;
    public long sourceStart;
    public long sourceEnd;
    public Corresponder(long rangeLength, long offSet, long sourceStart){
        this.offSet = offSet;
        this.sourceStart = sourceStart;
        sourceEnd = sourceStart + rangeLength;
    }
}

class dec5_1{
    long answer = 0;
    List<string> input;
    public dec5_1(List<string> input){
        this.input = input;
    }
    int[] getIndexes(List<string> list, string condition){
        return list.Select((e, i) => new { e, i}).Where(x => x.e == condition).Select(x => x.i).ToArray();
    }
    public long run(){
        List<long> seeds = input
            .Where(x => x.Contains("seeds:"))
            .First()
            .Split(' ')
            .Where(x => long.TryParse(x, out long result))
            .Select(x => Convert.ToInt64(x))
            .ToList();

        int[] blankSpaces = getIndexes(input, "");
        List<List<Corresponder>> corresponders = new List<List<Corresponder>>();
        for(int i = 0; i < blankSpaces.Length; i++){
            int blockLength = i + 1 < blankSpaces.Length ? blankSpaces[i+1] - blankSpaces[i] - 1: input.Count-1 - blankSpaces[i];
            List<string> block = input.GetRange(blankSpaces[i]+1, blockLength);
                corresponders.Add(block.Where(x => !x.Contains(":")).ToList().ConvertAll<Corresponder>(x => {
                    long[] splitted = x.Split(' ').Select(x => Convert.ToInt64(x)).ToArray();
                    long sourceStart = splitted[1];
                    long destinationStart = splitted[0];
                    long rangeLength = splitted[2];
                    return new Corresponder(rangeLength, destinationStart - sourceStart, sourceStart); 
                }));
        }
        for(int i = 0; i < seeds.Count; i += 2){
            bool inRange = true;
            long initSeed = seeds[i];
            long maxValue = seeds[i] + seeds[i+1] - 1;
            while(inRange){
                long source = initSeed;
                foreach(List<Corresponder> block in corresponders){
                    Corresponder? corresponder = block.Where(x => x.sourceStart <= source && x.sourceEnd > source).FirstOrDefault();
                    if(corresponder != null){
                        source = source + corresponder.offSet; 
                    }
                }
                if(answer == 0 || answer > source){
                    answer = source;
                }
                initSeed++;
                if(initSeed > maxValue){
                    Console.WriteLine($"Range: {i} done");
                    inRange = false;
                }
            }   
        }
        // List<long> locations = seeds.ConvertAll<long>(seed => {
        //     long source = seed;
        //     foreach(List<Corresponder> block in corresponders){
        //         Corresponder? corresponder = block.Where(x => x.sourceStart <= source && x.sourceEnd > source).FirstOrDefault();
        //         if(corresponder != null){
        //             source = source + corresponder.offSet; 
        //         }
        //     }
        //     return source;
        // });
        return answer;
    }
}