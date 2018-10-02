﻿using System.IO;
using System.Text;
using ManagedCuda;
using System;

namespace VectorAddInline
{
    class Program
    {
        static void Main(string[] args)
        {
        int N = 50000;
        int deviceID = 0;
        ManagedCuda.CudaContext ctx = new CudaContext(deviceID);

        string ptx = @"//
// Generated by NVIDIA NVVM Compiler
//
// Compiler Build ID: CL-21112126
// Cuda compilation tools, release 8.0, V8.0.43
// Based on LLVM 3.4svn
//

                .version 5.0
                .target sm_20, debug
                .address_size 64

    // .globl   VecAdd

                .visible .entry VecAdd(
            .param .u64 VecAdd_param_0,
            .param .u64 VecAdd_param_1,
            .param .u64 VecAdd_param_2,
            .param .u32 VecAdd_param_3
            )
        {
            .reg .pred  %p<3>;
            .reg .f32   %f<4>;
            .reg .b32   %r<7>;
            .reg .b64   %rd<13>;


            .loc 1 27 1
func_begin0:
                .loc    1 0 0

                        .loc 1 27 1

                        ld.param.u64    %rd1, [VecAdd_param_0];
                ld.param.u64    %rd2, [VecAdd_param_1];
                ld.param.u64    %rd3, [VecAdd_param_2];
                ld.param.u32    %r2, [VecAdd_param_3];
func_exec_begin0:
                .loc    1 29 1
tmp0:
                mov.u32     %r3, %ntid.x;
                mov.u32     %r4, %ctaid.x;
                mul.lo.s32  %r5, %r3, %r4;
                mov.u32     %r6, %tid.x;
                add.s32     %r1, %r5, %r6;
tmp1:
                .loc    1 30 1
                        setp.lt.s32 %p1, %r1, %r2;
                not.pred    %p2, %p1;
                @%p2 bra    BB0_2;
                bra.uni     BB0_1;

BB0_1:
                .loc    1 31 1
tmp2:
                    cvt.s64.s32 %rd4, %r1;
                    shl.b64     %rd5, %rd4, 2;
                    add.s64     %rd6, %rd1, %rd5;
                    ld.f32  %f1, [%rd6];
                    cvt.s64.s32 %rd7, %r1;
                    shl.b64     %rd8, %rd7, 2;
                    add.s64     %rd9, %rd2, %rd8;
                    ld.f32  %f2, [%rd9];
                    add.f32     %f3, %f1, %f2;
                    cvt.s64.s32 %rd10, %r1;
                    shl.b64     %rd11, %rd10, 2;
                    add.s64     %rd12, %rd3, %rd11;
                    st.f32  [%rd12], %f3;
tmp3:

BB0_2:
                    .loc    1 32 2
                            ret;
tmp4:
func_end0:
        }

        .file   1 ""I:/ManagedCuda/managedCuda/Samples/ManagedCudaSamples/vectorAddKernel/vectorAdd.cu"", 1477220395, 691

                .section .debug_info {
            .b32 464
                    .b8 2
                    .b8 0
                    .b32 .debug_abbrev
                    .b8 8
                    .b8 1

                    .b8 108
                    .b8 103
                    .b8 101
                    .b8 110
                    .b8 102
                    .b8 101
                    .b8 58
                    .b8 32
                    .b8 69
                    .b8 68
                    .b8 71
                    .b8 32
                    .b8 52
                    .b8 46
                    .b8 49
                    .b8 48

                    .b8 0
                    .b8 4
                    .b8 73
                    .b8 58
                    .b8 47
                    .b8 77
                    .b8 97
                    .b8 110
                    .b8 97
                    .b8 103
                    .b8 101
                    .b8 100
                    .b8 67
                    .b8 117
                    .b8 100
                    .b8 97
                    .b8 47
                    .b8 109
                    .b8 97
                    .b8 110
                    .b8 97
                    .b8 103
                    .b8 101
                    .b8 100
                    .b8 67
                    .b8 117
                    .b8 100
                    .b8 97
                    .b8 47
                    .b8 83
                    .b8 97
                    .b8 109
                    .b8 112
                    .b8 108
                    .b8 101
                    .b8 115
                    .b8 47
                    .b8 77
                    .b8 97
                    .b8 110
                    .b8 97
                    .b8 103
                    .b8 101
                    .b8 100
                    .b8 67
                    .b8 117
                    .b8 100
                    .b8 97
                    .b8 83
                    .b8 97
                    .b8 109
                    .b8 112
                    .b8 108
                    .b8 101
                    .b8 115
                    .b8 47
                    .b8 118
                    .b8 101
                    .b8 99
                    .b8 116
                    .b8 111
                    .b8 114
                    .b8 65
                    .b8 100
                    .b8 100
                    .b8 75
                    .b8 101
                    .b8 114
                    .b8 110
                    .b8 101
                    .b8 108
                    .b8 47
                    .b8 118
                    .b8 101
                    .b8 99
                    .b8 116
                    .b8 111
                    .b8 114
                    .b8 65
                    .b8 100
                            .b8 100
                            .b8 46
                            .b8 99
                            .b8 117

                            .b8 0
                            .b64 0
                            .b32 .debug_line
                            .b8 73
                            .b8 58
                            .b8 92
                            .b8 77
                            .b8 97
                            .b8 110
                            .b8 97
                            .b8 103
                            .b8 101
                            .b8 100
                            .b8 67
                            .b8 117
                            .b8 100
                            .b8 97
                            .b8 92
                            .b8 109
                            .b8 97
                            .b8 110
                            .b8 97
                            .b8 103
                            .b8 101
                            .b8 100
                            .b8 67
                            .b8 117
                            .b8 100
                            .b8 97
                            .b8 92
                            .b8 83
                            .b8 97
                            .b8 109
                            .b8 112
                            .b8 108
                            .b8 101
                            .b8 115
                            .b8 92
                            .b8 77
                            .b8 97
                            .b8 110
                            .b8 97
                            .b8 103
                            .b8 101
                            .b8 100
                            .b8 67
                            .b8 117
                            .b8 100
                            .b8 97
                            .b8 83
                            .b8 97
                            .b8 109
                            .b8 112
                            .b8 108
                            .b8 101
                            .b8 115
                            .b8 92
                            .b8 118
                            .b8 101
                            .b8 99
                            .b8 116
                            .b8 111
                            .b8 114
                            .b8 65
                            .b8 100
                            .b8 100
                            .b8 75
                            .b8 101
                            .b8 114
                            .b8 110
                            .b8 101
                            .b8 108

                            .b8 0
                            .b8 2

                            .b8 86
                            .b8 101
                            .b8 99
                            .b8 65
                            .b8 100
                            .b8 100

                            .b8 0
                            .b8 86
                            .b8 101
                            .b8 99
                            .b8 65
                            .b8 100
                            .b8 100

                            .b8 0
                            .b32 1
                            .b32 27
                            .b32 422
                            .b8 1
                            .b64 func_begin0
                            .b64 func_end0
                            .b8 1
                            .b8 156
                            .b8 3

                                    .b8 65

                                    .b8 0
                                    .b32 1
                                    .b32 27
                                    .b32 428
                                    .b8 9
                                    .b8 3
                                    .b64 VecAdd_param_0
                                    .b8 7
                                    .b8 3

                                    .b8 66

                                    .b8 0
                                    .b32 1
                                    .b32 27
                                    .b32 428
                                    .b8 9
                                    .b8 3
                                    .b64 VecAdd_param_1
                                    .b8 7
                                    .b8 3

                                    .b8 67

                                    .b8 0
                                    .b32 1
                                    .b32 27
                                    .b32 451
                                    .b8 9
                                    .b8 3
                                    .b64 VecAdd_param_2
                                    .b8 7
                                    .b8 3

                                    .b8 78

                                    .b8 0
                                    .b32 1
                                    .b32 27
                                    .b32 457
                                    .b8 9
                                    .b8 3
                                    .b64 VecAdd_param_3
                                    .b8 7
                                    .b8 4

                                    .b64 tmp0
                                    .b64 tmp4
                                    .b8 4

                                    .b64 tmp0
                                    .b64 tmp3
                                    .b8 4

                                    .b64 tmp0
                                    .b64 tmp3
                                    .b8 5

                                    .b8 105

                                    .b8 0
                                    .b32 1
                                    .b32 29
                                    .b32 457
                                    .b8 5
                                    .b8 144
                                    .b8 177
                                    .b8 228
                                    .b8 149
                                    .b8 1
                                    .b8 2
                                    .b8 0
                                    .b8 0
                                    .b8 0
                                    .b8 0
                                    .b8 6

                                    .b8 118
                                    .b8 111
                                    .b8 105
                                    .b8 100

                                    .b8 0
                                    .b8 7

                                    .b32 434
                                    .b8 12
                                    .b8 8

                                    .b32 439
                                    .b8 9

                                    .b8 102
                                    .b8 108
                                    .b8 111
                                    .b8 97
                                    .b8 116

                                    .b8 0
                                    .b8 4
                                    .b32 4
                                    .b8 7

                                    .b32 439
                                    .b8 12
                                    .b8 9

                                    .b8 105
                                    .b8 110
                                    .b8 116

                                    .b8 0
                                    .b8 5
                                    .b32 4
                                    .b8 0
        }
        .section .debug_abbrev {
            .b8 1

                    .b8 17

                    .b8 1

                    .b8 37

                    .b8 8

                    .b8 19

                    .b8 11

                    .b8 3

                    .b8 8

                    .b8 17

                    .b8 1

                    .b8 16

                    .b8 6

                    .b8 27

                    .b8 8

                    .b8 0

                    .b8 0

                    .b8 2

                    .b8 46

                    .b8 1

                    .b8 135
                    .b8 64

                    .b8 8

                    .b8 3

                    .b8 8

                    .b8 58

                    .b8 6

                    .b8 59

                    .b8 6

                    .b8 73

                    .b8 19

                    .b8 63

                    .b8 12

                    .b8 17

                    .b8 1

                    .b8 18

                    .b8 1

                    .b8 64

                    .b8 10

                    .b8 0

                    .b8 0

                    .b8 3

                    .b8 5

                    .b8 0

                    .b8 3

                    .b8 8

                    .b8 58

                    .b8 6

                    .b8 59

                    .b8 6

                    .b8 73

                    .b8 19

                    .b8 2

                    .b8 10

                    .b8 51

                    .b8 11

                    .b8 0

                    .b8 0

                    .b8 4

                    .b8 11

                    .b8 1

                    .b8 17

                    .b8 1

                    .b8 18

                    .b8 1

                    .b8 0

                    .b8 0

                    .b8 5

                    .b8 52

                    .b8 0

                    .b8 3

                    .b8 8

                    .b8 58

                    .b8 6

                    .b8 59

                    .b8 6

                    .b8 73

                    .b8 19

                    .b8 2

                    .b8 10

                    .b8 51

                    .b8 11

                    .b8 0

                    .b8 0

                    .b8 6

                    .b8 59

                    .b8 0

                    .b8 3

                    .b8 8

                    .b8 0

                    .b8 0

                    .b8 7

                    .b8 15

                    .b8 0

                    .b8 73

                    .b8 19

                    .b8 51

                    .b8 11

                    .b8 0

                    .b8 0

                    .b8 8

                    .b8 38

                            .b8 0

                            .b8 73

                            .b8 19

                            .b8 0

                            .b8 0

                            .b8 9

                            .b8 36

                            .b8 0

                            .b8 3

                            .b8 8

                            .b8 62

                            .b8 11

                            .b8 11

                            .b8 6

                            .b8 0

                            .b8 0

                            .b8 0

        }
        .section .debug_ranges {
        }
        .section .debug_pubnames {
            .b32 25
                    .b8 2
                    .b8 0
                    .b32 .debug_info
                    .b32 464
                    .b32 195
                    .b8 86
                    .b8 101
                    .b8 99
                    .b8 65
                    .b8 100
                    .b8 100
                    .b8 0

                    .b32 0
        }
            ";
            System.IO.Stream moduleImage = new MemoryStream(Encoding.UTF8.GetBytes(ptx));
            CudaKernel kernel = ctx.LoadKernelPTX(moduleImage, "VecAdd");
            kernel.GridDimensions = (N + 255) / 256;
            kernel.BlockDimensions = 256;

            // Allocate input vectors h_A and h_B in host memory
            float[] h_A = new float[N];
            float[] h_B = new float[N];

            // TODO: Initialize input vectors h_A, h_B
            System.Random random = new System.Random();
            for (int i = 0; i < N; ++i) h_A[i] = (float)random.NextDouble();
            for (int i = 0; i < N; ++i) h_B[i] = (float)random.NextDouble();

            // Allocate vectors in device memory and copy vectors from host memory to device memory 
            CudaDeviceVariable<float> d_A = h_A;
            CudaDeviceVariable<float> d_B = h_B;
            CudaDeviceVariable<float> d_C = new CudaDeviceVariable<float>(N);

            // Invoke kernel
            kernel.Run(d_A.DevicePointer, d_B.DevicePointer, d_C.DevicePointer, N);

            // Copy result from device memory to host memory
            // h_C contains the result in host memory
            float[] h_C = d_C;

			for (int i = 0; i < 4; ++i)
				System.Console.WriteLine(h_C[i]);

        }
    }
}
