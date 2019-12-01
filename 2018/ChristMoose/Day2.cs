using System;
using System.Collections.Generic;
using System.Linq;

namespace ChristMoose
{
    internal class Day2
    {
        private static string Input => "bazvmqthjtrnlosiecxyghkwud\r\npazvmqbijirzlosiecxyghkwud\r\npazvtqbmjtrnlosiecxyghkwzd\r\npazvmqbfjtrjlosnlcxyghkwud\r\npazvkqbfjtrtlosiecjyghkwud\r\npaztmqbfjtrnbosiecxyglkwud\r\npazvmqbfjtunlosievxmghkwud\r\npazvmqbfjtmngosiecyyghkwud\r\njazvmqbfjtrnlosiecxygikpud\r\npazvqqbfctrnlosimcxyghkwud\r\npazvmqbfjtrnwogiecxyihkwud\r\npazvmqbfjtrqlojiecxeghkwud\r\npayvmqbfjtrzlosiecxyghkwuk\r\npkzvmqnfjtrnlosieciyghkwud\r\npazvmqqfjtrnldsiecxyghkwui\r\npazvmqbfttrqlosiecxywhkwud\r\ngazvmybfjthnlosiecxyghkwud\r\npazvmqbfjtrnlasiecxygptwud\r\npktvmqbfjtrnwosiecxyghkwud\r\npazvmqwfjtrnlosiecxgghkkud\r\npazvmzkbjtrnlosiecxyghkwud\r\npazvmqbfjtrnloslecxyghuwui\r\npezvmqbfjtrnlesieyxyghkwud\r\ncazvmqbfjrrnlosiecxyghkmud\r\npazvmqrfjjrnlosiecxyghkwnd\r\npazvmqbgjtrnlosiecxyphtwud\r\npazvmqbvmtrnlosiecxyghkpud\r\npazdmqbfjtrnlosiecxyuhkpud\r\npazvmqbflnrnloshecxyghkwud\r\npazvvqbfjprilosiecxyghkwud\r\npazvwqbfjtrllosiecxyghknud\r\npazvmqbfjtrnloniecxdghkaud\r\npazvmqbfjtrnlvsuecxynhkwud\r\nptzvmqwfjtrnlosieccyghkwud\r\npkzvmqbjjtrnlosiecryghkwud\r\npazvmqqfjtrexosiecxyghkwud\r\npazgmqbfjtrneoyiecxyghkwud\r\npaznmqbfjtrnlosiecxydhkwzd\r\npazvmqbfjtrnaosiwcxsghkwud\r\npazomqbfjxrnlosiewxyghkwud\r\npazsmqbfjprnlosiecxrghkwud\r\npazvmqbfqtrnoosiecxygmkwud\r\naazvmqbfjtrnlosiacxyghjwud\r\npazviqbfjtrnlobiecxygrkwud\r\nqazwmqbfjhrnlosiecxyghkwud\r\npazvmqbfftrnlosiqcxygfkwud\r\npatvmqbfjtonlosircxyghkwud\r\npazvmqbfjtrnlomaecxyghkpud\r\npaztmqbfjtrulossecxyghkwud\r\npazvmqbijtrnlobiecxyghkwkd\r\npazvsqbfjtrnlospecxyghkqud\r\npbzmmqbfjtrnlosiecxyghkwhd\r\npezvkqbfjtenlosiecxyghkwud\r\nrazvmqbfjkrnlosiecxeghkwud\r\npazcmqbfjtrnloriecxyghkgud\r\npazvmqbfftfnlosiecvyghkwud\r\npazvmqpujtrnlosiepxyghkwud\r\npatvgqbfjtrnloslecxyghkwud\r\npazvmqbfltrnlosibcxyghswud\r\npazvmebfjtrnlosaecxyehkwud\r\npazdmqbejtrnlosiecxyghrwud\r\npazvmcbfntrplosiecxyghkwud\r\npszvmqbfjtrnlosivcfyghkwud\r\npuzvmqbfjtrnloeiecxyxhkwud\r\npazvmqbfjtrivooiecxyghkwud\r\npazvyqbfjtrngosiwcxyghkwud\r\npauvmqbfjtrnlosimexyghkwud\r\npazvmqbfjtrnwoshecxeghkwud\r\ndazvmqbfjtrnloshecxygxkwud\r\npazvmqbfjtrtdosiecxyghvwud\r\npazxmqbfjtrnlosieceyghjwud\r\npazvmqbfjtrnlosihexjghkwud\r\npazvmqbfjsrnlosiecxughiwud\r\nphzvcqbfjtrqlosiecxyghkwud\r\npazvmibfjtrnlosjecxxghkwud\r\npazvmqbfjtrbeosiecxlghkwud\r\npazvmqyfjttolosiecxyghkwud\r\nfawvmqbfjtrnlosiecxyghkwhd\r\npazvmqbfjprnxosiecxyghkbud\r\nmacvmqbfjtrnlosiesxyghkwud\r\npazsmqbfjtrflouiecxyghkwud\r\npacvmqbfjtrnltsiecxyghcwud\r\npazvmqbfjtymlosiecxygykwud\r\npazvmqbfjtrclosiecxygukwmd\r\npazvmqbfjtrnlobiecxphhkwud\r\nmazvmqbhitrnlosiecxyghkwud\r\npazvmqdtjtrnlrsiecxyghkwud\r\npazvmqbfjgrnllsieczyghkwud\r\npazvmqbfjtrilosiecxxgikwud\r\npazvmqbjjtrnlosreceyghkwud\r\npaxvmmbfjtrilosiecxyghkwud\r\npazqmwbfjtrnlowiecxyghkwud\r\npazvmqbfjfrnqosiecxyghkwui\r\npazvmqbfjtrrgosiecxyghswud\r\npazvmqnfjtrnlosiecsyghkwmd\r\npaiemqbmjtrnlosiecxyghkwud\r\npazvmqbfdtqnlosiecxyjhkwud\r\npazvmxbfjthndosiecxyghkwud\r\npqzvmqbfjtrnlosiecxbghkzud\r\npagrmqbfjtrnlosiecxygskwud\r\npazamqtfjtrnsosiecxyghkwud\r\npazvmqbfjtrnldshecxyzhkwud\r\npazvmnbfjtrllosieclyghkwud\r\nsnzvmqbfjnrnlosiecxyghkwud\r\npazvsqbfjdrnlosiecxyghswud\r\npazvmqnfjfrnlosiecsyghkwud\r\npazvmqbfjtrnlosiecxjghowum\r\npazvmqbfjtjnlosieczygfkwud\r\npazvmqbsjtrnloziecxyghkeud\r\npazvxqbgjtrnlooiecxyghkwud\r\npazvmqbfjtrnlooiecxmyhkwud\r\npazvmqbyftrnlosgecxyghkwud\r\npazvmqbfjtrnlosiwcxyqhksud\r\npazvmqkyjtrnlokiecxyghkwud\r\npazfmqbfjtrnlosijcxyohkwud\r\npazvmqbfjtrnlociecxygikcud\r\nfazvmqbfjtrnlosiecxyjhkuud\r\npazvmqbojtknlohiecxyghkwud\r\npazvmqbfjtgnlosbecxyghkwux\r\npazvmqbfjtrnlocieckoghkwud\r\npazvdqbfjtrlltsiecxyghkwud\r\npazvmqbfjtsnlfsiecxyglkwud\r\nprzvpqbfjtrnyosiecxyghkwud\r\npazvmbrfjtrnlosiecxmghkwud\r\ndazvmqbfttrnlostecxyghkwud\r\npazvmqbfttdnlosiecxygwkwud\r\npazvmqbvitrnlosieexyghkwud\r\npazvmqbfjhrnlosjecxyvhkwud\r\npazvmqbfstrnlosiecxyggkwpd\r\nbazvmqbfjtrnlmsiecxyohkwud\r\npatmmqbfjtrnlosizcxyghkwud\r\npazvmqbfwtrglosieqxyghkwud\r\npazvmqbfjtrnlosiecxdhhkwmd\r\npazvmqbfjdrnlosnexxyghkwud\r\noazrrqbfjtrnlosiecxyghkwud\r\npazvmqbfjcrnlosiecxygakwjd\r\npazvmqbfjtrnlosifcxfghkwyd\r\npazvmnbfjtrnlosiecxyahzwud\r\npazvmqbfgtrnlojiecxyghkgud\r\npazvmqbfjtrnlaliecxyghkwuy\r\npazvmqbfjtrnlfsiecrtghkwud\r\npazvmqbkjtrnloswecxdghkwud\r\npazvtqbfjtdnlosiecxyghkwuu\r\npozvmqbfrtrnlosiesxyghkwud\r\npayvmqbfjornlossecxyghkwud\r\npazvuqbfjtrnlosiscxyghkpud\r\npgzcmqbfjtrnlotiecxyghkwud\r\npazvvqbfjtrnlobieyxyghkwud\r\npazycqbfjtrnlosiecxyzhkwud\r\npizvdqbfjtrnlosiecxbghkwud\r\npazvmqbfjtrnloqiecxmgtkwud\r\ngazvmqbfjtrnlusiecxpghkwud\r\npazvmqdfjtralosiecxyghkwmd\r\npazvmqbfjtmnlosiecxywhawud\r\npazvlqbfjtrnlosqecxyghqwud\r\npazvmqbfjtrnlhsneixyghkwud\r\nkazvmqbfjtrqlosimcxyghkwud\r\npazvmwbfjtrclosiecxyghkuud\r\npazvmqjfjtrnlosieckyghpwud\r\npezvmqbgjtrnloseecxyghkwud\r\npazvqqbfjtfnlosvecxyghkwud\r\noazvmqbfjtunlosiecxyghkwad\r\npazvmqbfjtrncoswecxyghfwud\r\npazvyqbfjtrnlosqecxygtkwud\r\npazvmqbfjtrvlzsiecxygwkwud\r\npazvmqbfjjrnlosiekxylhkwud\r\nmadvmqbfjtrnlosircxyghkwud\r\npazvmybfjtrnlisiecxyghkwbd\r\npazvmqbjjixnlosiecxyghkwud\r\npazvmqefjtrnloqiecxyghhwud\r\npazveqbfjtrnlosiecgygzkwud\r\npazvmqbfjtrxlosiecxmgwkwud\r\nuazvmqufjtrnlosiecxyghkwuo\r\npasymqbfjtrnlosiecxyghowud\r\npazvmqbfjtlnlpsiecxyghswud\r\npnzvmqbfjprnloszecxyghkwud\r\npafjmqcfjtrnlosiecxyghkwud\r\npazvmqxfbtrnloqiecxyghkwud\r\npazvmzbfjtrnposiccxyghkwud\r\npazvmqbfjotulosiecxyghkwud\r\npazvmqbfotrnlosgecxykhkwud\r\nprzvmqbfjtrnlosiecxyqhkwcd\r\npazvmqbfjtsnlogiecxyyhkwud\r\npazvmqbfrtrnlzsiecxyghkwug\r\npazvmqbfjtrnlosiecxzgukwuo\r\npqzvmqbqjtrnlosdecxyghkwud\r\npazvmqbfjtqqlosiecxughkwud\r\npazvmqbfjtrnlosiedhyphkwud\r\npazsmqbcutrnlosiecxyghkwud\r\npazvmqbgrtrnlosiecxyghpwud\r\npazemqbfjtznlosiecxyghkvud\r\npazvkqbfjtrilosiecxyghkwod\r\npfzvmqbfjtrnlopiecxygjkwud\r\npazvmqvfjtreloniecxyghkwud\r\npazvmqbfjernljsiecxgghkwud\r\npazvmqikjtrnlosiecxyghqwud\r\npazvmqbfjtrnpesoecxyghkwud\r\nfazvmqbfjtrnlosihchyghkwud\r\npazvmqbfjtgnloanecxyghkwud\r\npazvmqsfjqrnlosiecxychkwud\r\nparvmqbfjtrnlosiecxygfuwud\r\nprzvmqbfjtrhlosihcxyghkwud\r\npazvmqbcjtrnlosimcxgghkwud\r\npazvmqbfjtrnlosceciyjhkwud\r\npazvkqbfjtrylosivcxyghkwud\r\npazvmqbfjtrnlgsieoxyghdwud\r\npazvmqnfstrnlowiecxyghkwud\r\npazvmqbfdtrnlosieumyghkwud\r\npazvmqbfjtrnlosyecxfghkwul\r\npazvmqbfjtrclosivcxyghkcud\r\npazjmqbfjtrnlosiecxygokwkd\r\nhazvmqbfjtrflosiecxzghkwud\r\nwazvmqbfjtrnlomiecxyphkwud\r\nyazvmqbfjirnkosiecxyghkwud\r\npczvmqbfjtrnlohiecxyghkwpd\r\npazvmqbfotrbeosiecxlghkwud\r\npazvmqbfjtrplosiecxynhzwud\r\npaxvbqbwjtrnlosiecxyghkwud\r\npazvmqvfjtrnlosiecbyghqwud\r\npazjmqbfjtrnlosiecxoghkwed\r\npazvmqbfjtreljsitcxyghkwud\r\nmazamqbfjtrnlosiecxoghkwud\r\npazvmqbfjjrnposiscxyghkwud\r\npbrvmqbfjtrnloliecxyghkwud\r\npazvmqbfjtrnlosiecxgghkyyd\r\npmzvmqbfntrnlosiecxyghkwuw\r\npazvzqbfjtrnlosienxyghzwud\r\npazvmqifjtvnlosrecxyghkwud\r\ntazvmqbhjtjnlosiecxyghkwud\r\npazvmqbfjtlnxosiecxyghkwuo\r\npazvmqbfjennlosiecxyghkwxd\r\npahvmqbfjhrnlosiecxythkwud\r\npazvmlkfjtrnlxsiecxyghkwud\r\npfzvmqbojtrnlosieciyghkwud\r\npazvbqbfjtrollsiecxyghkwud\r\neazvmqbfjtrnlosiecayghkoud\r\npazvmqbfjtjnlvsiecxyghkwsd\r\npazvoqbojtrnlosiecfyghkwud\r\npazvmqbfjtuslosiecxyghksud\r\npazvmqbfjnrnlosiedxyghkwup\r\npazvmqbjjtrnlosieaxyghdwud\r\npazccqbfjtrhlosiecxyghkwud\r\npbzvmqkfjtrnlosievxyghkwud\r\npazvmqrljtrnlosiscxyghkwud\r\npazvmqbfjfoqlosiecxyghkwud\r\npazcmqbfjtrnlosiecxyihkwuf\r\npszvmqbfjtrnnosiacxyghkwud\r\naazvmqbfjtrnlosieyxyghkwld\r\npazvrqbfntrnlosiycxyghkwud\r\npkzvoqbfjtrnlosiecxyghxwud";
        private static string InputTest => "abcde\r\nfghij\r\nklmno\r\npqrst\r\nfguij\r\naxcye\r\nwvxyz";

        public static int CalculateChecksum()
        {
            var strings = Input.Split("\r\n");

            int numberOfDuplicateLetters = 0;
            int numberOfTriplettLetters = 0;

            foreach (var str in strings)
            {
                var dictionary = new Dictionary<char, int>();
                var duplicateValues = str.Where(character => str.Count(c => c == character) > 1).Distinct();

                foreach (var duplicateValue in duplicateValues)
                {
                    var count = str.Count(s => s == duplicateValue);
                    dictionary.Add(duplicateValue, count);
                }

                if (dictionary.Count <= 0) continue;
                if (dictionary.Any(x => x.Value == 2))
                {
                    numberOfDuplicateLetters++;
                }
                if (dictionary.Any(x => x.Value == 3))
                {
                    numberOfTriplettLetters++;
                }
            }

            int product = numberOfDuplicateLetters * numberOfTriplettLetters;

            return product;
        }


        public static string FindTheCommonBoxId()
        {
            var strings = Input.Split("\r\n");

            for (var strIndex = 0; strIndex < strings.Length; strIndex++)
            {
                var str = strings[strIndex];

                for (var i = 0; i < str.Length; i++)
                {
                    for (var strIndex2 = 0; strIndex2 < strings.Length; strIndex2++)
                    {
                        var str2 = strings[strIndex2];

                        for (var j = 0; j < str2.Length; j++)
                        {
                            var firsStringManipulated = str.Remove(i, 1);
                            var secondStringManipulated = str2.Remove(j, 1);

                            if (firsStringManipulated.Equals(secondStringManipulated) && strIndex != strIndex2)
                            {
                                return firsStringManipulated;
                            }
                        }
                    }
                }
            }

            throw new Exception("oh ho no");
        }
    }
}