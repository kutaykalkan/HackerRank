using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLandMetro
{
    class Program
    {
        static void Main(string[] args) {
            long[] line1 = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            long n = line1[0];
            long m = line1[1];
            long numTracks = line1[2];
            long count = (numTracks == 0) ? n * m : 0;
            if (numTracks > 0) {
                Dictionary<long, Tuple<long, long>> tracks = new Dictionary<long, Tuple<long, long>>();
                for (long i = 0; i < numTracks; i++) {
                    long[] track = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                    long trackNo = track[0];
                    long start = track[1];
                    long end = track[2];
                    if (!tracks.ContainsKey(trackNo)) {
                        tracks.Add(trackNo, Tuple.Create(start, end));
                        count = count + (start - 1) + (m - end);
                    }
                    else {
                        if (count > 0) {
                            long previousStart = tracks[trackNo].Item1;
                            long previousEnd = tracks[trackNo].Item2;
                            if (start < previousStart && (end >= previousStart && end <= previousEnd)) {
                                count = count - (previousStart - start);
                            }
                            else if (end > previousEnd && (start >= previousStart && start <= previousEnd))
                                count = count - (end - previousEnd);
                            else if (start >= previousEnd && end > previousEnd) {
                                if (start == previousEnd)
                                    count = count - (end - start);
                                else
                                    count = count - (end - start + 1);
                            }
                            else if (end <= previousStart && start < previousStart) {
                                if (end == previousStart)
                                    count = count - (end - start);
                                else
                                    count = count - (end - start + 1);
                            }

                            else if (start < previousStart && end > previousEnd)
                                count = count - ((previousStart - start) + (end - previousEnd));
                            tracks[trackNo] = Tuple.Create<long, long>(Math.Min(start, previousStart), Math.Max(end, previousEnd));
                        }
                    }
                }

                count = count + (n - tracks.Count) * m;

            }
            /*
            if (numTracks > 0) {
                Dictionary<long, HashSet<long>> tracks = new Dictionary<long, HashSet<long>>();
                for (long i = 0; i < numTracks; i++) {
                    long[] track = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                    long trackNo = track[0];
                    long start = track[1];
                    long end = track[2];
                    if (!tracks.ContainsKey(trackNo)) {
                        HashSet<long> open = new HashSet<long>();
                        for (long k = 1; k <= m; k++) {
                            if (k < start || k > end)
                                open.Add(k);
                        }
                        tracks.Add(trackNo, open);
                    }
                    else {
                        for (long k = start; k <= end; k++) {
                            tracks[trackNo].Remove(k);
                        }
                    }
                }

                count = (n - tracks.Count) * m;
                foreach (HashSet<long> open in tracks.Values) {
                    count = count + open.Count;
                }
                
            }*/

            Console.WriteLine(count);
            Console.Read();
        }
    }
}
