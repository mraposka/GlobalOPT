# Welcome To GlobalOPT
### GlobalOPT is optimization project(Lorem ipsum). This project runs this python project with Docker [OptFramework](https://github.com/demirmehmet0/GlobalOptFramework)

# Usage
#### 1-Run the application (recomended in administrator)
#### 2-Select an algorithm and insert parameters
#### 3-Application will save outputs on the desktop

# Algorithm Options
        ALGORITHM=1 - XZLBZ                             -> (MATRIX_PATH, ITERATION)
        ALGORITHM=2 - BP                                -> (MATRIX_PATH, NUM_MATRICES, THRESHOLD, DEPTH)
        ALGORITHM=3 - RNBP                              -> (MATRIX_PATH, ITERATION)
        ALGORITHM=4 - A1                                -> (MATRIX_PATH, ITERATION)
        ALGORITHM=5 - A2                                -> (MATRIX_PATH, ITERATION)
        ALGORITHM=6 - Paar1                             -> (MATRIX_PATH, NUM_MATRICES, THRESHOLD)
        ALGORITHM=7 - Paar2                             -> (MATRIX_PATH, NUM_MATRICES, THRESHOLD)
        ALGORITHM=8 - LWFWSW                            -> (MATRIX_PATH, ITERATION)
        ALGORITHM=9 - BFI                               -> (MATRIX_PATH, ITERATION)
        ALGORITHM=10 - BFI-Paar1                        -> (MATRIX_PATH, ITERATION)
        ALGORITHM=11 - BFI-RPaar1                       -> (MATRIX_PATH, ITERATION)
        ALGORITHM=12 - BFI-BP                           -> (MATRIX_PATH, ITERATION)
        ALGORITHM=13 - BFI-A1                           -> (MATRIX_PATH, ITERATION)
        ALGORITHM=14 - BFI-A2                           -> (MATRIX_PATH, ITERATION)
        ALGORITHM=15 - BFI-RNBP                         -> (MATRIX_PATH, ITERATION)
        ALGORITHM=16 - BFI-BP-depthConstrained          -> (MATRIX_PATH, NUM_MATRICES, THRESHOLD, DEPTH, BFI)

# How does it work?
#### 1- Application will check docker and git installations. If you don't have docker or git it will automatically install (with permission ofc). 
#### 2- After installation, application will clone the [OptFramework](https://github.com/mraposka/DockerOPT) repo, build it on docker(ubuntu) and runs it with your parameters.
