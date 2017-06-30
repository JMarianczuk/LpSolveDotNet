# LpSolveDotNet
LpSolveDotNet is a .NET wrapper for the Mixed Integer Linear Programming (MILP) solver lp_solve. The wrapper works with both 32-bit and 64-bit applications.

The solver lp_solve solves pure linear, (mixed) integer/binary, semi-cont and special ordered sets (SOS) models.

## Usage
To use LpSolveDotNet follow these steps:

1. Add NuGet package LpSolveDotNet to your project using NuGet Package Manager: `Install-Package LpSolveDotNet`. This will
   * Add a reference to the LpSolveDotNet library
   * Add a post-build step to your project file that will copy the native library lpsolve55.dll to your output folder. Note that this will copy both the 32-bit and 64-bit versions of the library and LpSolveDotNet  will load the correct one at runtime.
2. In your project, add a call to either of the `LpSolveDotNet.LpSolve.Init()` methods defined below. Both of them will modify the *PATH* environment variable of the current process to allow it to find the lpsolve methods. Note that calling multiple times these methods has no side effects (unless you pass different parameters).
   * *Init(dllFolderPath)*:  This method will use the given *dllFolderPath* to find *lpsolve55.dll*.
   * *Parameterless Init()*:  This method will determine where is *lpsolve55.dll* based on `IntPtr.Size`, using either `NativeBinaries\win64` or `NativeBinaries\win32` relative to executing assembly.
3. Use one of the factory methods on `LpSolve` class to create an `LpSolve` instance:
   * make_lp
   * read_LP
   * read_freeMPS
   * read_MPS
   * read_XLI
4. Place the returned `LpSolve` instance into a `using` statement so it is properly disposed of when done with it.
4. Use methods on that instance. The methods are like the [official lpsolve documentation](http://lpsolve.sourceforge.net/5.5/index.htm) except the first parameter which is passed implicitly by this instance.

*In a future version, there will be documentation on the methods and the API will look more like .NET than C. Don't worry the old syntax will stay there.*

## Examples
You can see examples in the [Demo project](./src/LpSolveDotNet.Demo/LpSolveDotNet.Demo.csproj) translated from lpsolve's original C# samples.

* [Formulation of an lp model in lpsolve](./src/LpSolveDotNet.Demo/FormulateSample.cs)
* [demo inside lp_solve_5.5.2.3_cs.net.zip](./src/LpSolveDotNet.Demo/Program.cs)

## Releases
You can see the [release history](./ReleaseNotes.md).
