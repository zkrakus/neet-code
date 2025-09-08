namespace neetcode.ArraysAndHashing;

// Amazon Question
// You are given two integer arrays of equal length fileSize and affinit.
// There are n files; the i-th virus attacks the i-th file and is effective against any file whose size equals affinity[i].
// In one operation, you may choose two indices i and j and swap fileSize[i] with fileSize[j].
// Return the minimum number of operations needed so that for every i fileSzie[i] != affinity[i]
public static class MinSwapsToAvoidAffinity
{
    public static class MinSwapsAvoidAffinity
    {
        /// <summary>
        /// Returns the minimum number of swaps needed so that for all i,
        /// fileSizes[i] != affinities[i]. If impossible, returns -1.
        /// </summary>
        public static int MinSwaps(int[] fileSizes, int[] affinities)
        {
            // 1) Collect indices where fileSizes[i] == affinities[i] (conflicts).
            List<int> conflictingIndices = new();
            for (int i = 0; i < fileSizes.Length; i++)
            {
                if (fileSizes[i] == affinities[i])
                    conflictingIndices.Add(i);
            }

            // If no indexes conflict. We're done.
            int conflictCount = conflictingIndices.Count;
            if (conflictCount == 0)
                return 0;

            // 2) Count how often each value occurs among the conflicts.
            var conflictFrequency = new Dictionary<int, int>();
            int dominantValue = 0;
            int dominantCount = 0;

            foreach (int i in conflictingIndices)
            {
                int conflictingValue = fileSizes[i];
                conflictFrequency.TryGetValue(conflictingValue, out int count);
                conflictFrequency[conflictingValue] = ++count;

                if (count > dominantCount)
                {
                    dominantCount = count;
                    dominantValue = conflictingValue;
                }
            }

            // 3) If no single value dominates more than half, just rotate them.
            if (dominantCount <= conflictCount / 2) // divide in half because we can fix 2 conflicts with 1 swap.
                return (conflictCount + 1) / 2;

            // 4) Otherwise, calculate how many extra non-dominant values we need.
            int extrasNeeded = 2 * dominantCount - conflictCount;

            // Count available "import" spots from outside conflicts.
            int importableCount = 0;
            for (int i = 0; i < fileSizes.Length; i++)
            {
                if (fileSizes[i] != affinities[i]      // this index is already good
                    && fileSizes[i] != dominantValue   // value isn't dominant
                    && affinities[i] != dominantValue) // target slot won't clash with dominant
                {
                    importableCount++;
                }
            }

            if (importableCount < extrasNeeded)
                return -1;

            // Total swaps = conflicts fixed + extras imported.
            return conflictCount + extrasNeeded;
        }
    }
}
